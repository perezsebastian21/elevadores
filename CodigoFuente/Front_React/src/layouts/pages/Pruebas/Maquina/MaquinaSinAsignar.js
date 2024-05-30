import { useState, useEffect } from "react";
import axios from "axios";

// @mui material components
import Card from "@mui/material/Card";
import Select from "@mui/material/Select";
import { Link, useNavigate, useParams } from "react-router-dom";
import InputLabel from "@mui/material/InputLabel";
import MenuItem from "@mui/material/MenuItem";
import FormControl from "@mui/material/FormControl";
// Material Dashboard 2 PRO React components
import MDBox from "components/MDBox";
import MDButton from "components/MDButton";
import MDTypography from "components/MDTypography";
import MDAlert from "components/MDAlert";
import PropTypes from "prop-types";
import Grid from "@mui/material/Grid";
// Material Dashboard 2 PRO React examples
import DashboardLayout from "examples/LayoutContainers/DashboardLayout";
import DashboardNavbar from "examples/Navbars/DashboardNavbar";
import DataTable from "examples/Tables/DataTable";

function MaquinaSinAsignar() {
  const navigate = useNavigate();
  const { id } = useParams();
  const [dataTableData, setDataTableData] = useState([]);
  const [errorAlert, setErrorAlert] = useState({ show: false, message: "", type: "error" });
  const [tecnicos, setTecnicos] = useState([]);
  const [selectedItem, setSelectedItem] = useState("");
  const [autoAsignacionError, setAutoAsignacionError] = useState("");
  const [autoAsignacionMessage, setAutoAsignacionMessage] = useState("");
  const token = sessionStorage.getItem("token");

  useEffect(() => {
    axios
      .get(process.env.REACT_APP_API_URL + `conservadora/GetRespTec?idCons=${id}`, {
        headers: {
          Authorization: `Bearer ${token}`, // Envía el token en los headers
        },
      })

      .then((response) => setTecnicos(response.data))
      .catch((error) => {
        console.error("Error fetching technicians:", error);
        // Handle error
      });
  }, []);

  useEffect(() => {
    axios
      .get(process.env.REACT_APP_API_URL + `maquina/GetXConsSinRespTec?idCons=${id}`, {
        headers: {
          Authorization: `Bearer ${token}`, // Envía el token en los headers
        },
      })
      .then((response) => setDataTableData(response.data))
      .catch((error) => {
        if (error.response) {
          const statusCode = error.response.status;
          let errorMessage = "";
          let errorType = "error";
          if (statusCode >= 400 && statusCode < 500) {
            errorMessage = `Error ${statusCode}: Hubo un problema con la solicitud del cliente.`;
          } else if (statusCode >= 500) {
            errorMessage = `Error ${statusCode}: Hubo un problema en el servidor.`;
          }
          setErrorAlert({ show: true, message: errorMessage, type: errorType });
        } else {
          setErrorAlert({
            show: true,
            message: "Ocurrió un error inesperado. Por favor, inténtalo de nuevo más tarde.",
            type: "error",
          });
        }
      });
  }, [id]);

  useEffect(() => {
    if (autoAsignacionMessage && autoAsignacionMessage !== "") {
      // Realizar una nueva solicitud para obtener los datos actualizados
      axios
        .get(process.env.REACT_APP_API_URL + `maquina/GetXConsSinRespTec?idCons=${id}`, {
          headers: {
            Authorization: `Bearer ${token}`, // Envía el token en los headers
          },
        })

        .then((response) => {
          setDataTableData(response.data);
          setTimeout(() => {
            setAutoAsignacionMessage("");
          }, 4000); // Limpiar el mensaje de autoasignación
        })
        .catch((error) => {
          // Manejar errores aquí
          console.error("Error al obtener datos actualizados:", error);
        });
    }
  }, [autoAsignacionMessage, id]);

  const handleEdicion = (rowData) => {
    if (rowData && rowData.idTipoObra) {
      const productId = rowData.idTipoObra;
      const url = `/TipoObraFE/Edit/${productId}`;
      navigate(url);
    } else {
      console.error("El objeto rowData o su propiedad 'id' no están definidos.");
    }
  };

  const handleAutoasignar = () => {
    if (!selectedItem) {
      setAutoAsignacionError("Por favor, selecciona un técnico antes de autoasignar.");
      return;
    }
    // Obtener listado de idMaquina
    const idMaquinas = dataTableData.map((item) => item.idMaquina);

    // Enviar datos al backend
    axios
      .put(
        process.env.REACT_APP_API_URL + "maquina/autoasignarRespTecxMaq",
        {
          idRepTecnico: selectedItem,
          idMaquina: idMaquinas,
        },
        {
          headers: {
            Authorization: `Bearer ${token}`, // Envía el token en los headers
          },
        }
      )
      .then((response) => {
        console.log("Datos enviados correctamente al backend:", response.data);
        // Verificar el código de estado de la respuesta
        if (response.status === 206) {
          // Mostrar una alerta para informar que la petición se completó parcialmente
          setAutoAsignacionMessage(response.data); // Suponiendo que el mensaje está en response.data.message
          console.log("Mensaje del response 206" + response.data);
        } else if (response.status === 200) {
          // Mostrar una alerta para informar que la petición se completó parcialmente
          setAutoAsignacionMessage(response.data); // Suponiendo que el mensaje está en response.data.message
          console.log("Mensaje del response 200" + response.data);
        }
      })
      .catch((error) => {
        console.error("Error al enviar datos al backend:", error);
        // Manejar el error aquí
      });
  };

  return (
    <>
      <DashboardLayout>
        <DashboardNavbar />
        {autoAsignacionError && (
          <Grid container justifyContent="center">
            <Grid item xs={12} lg={12}>
              <MDBox pt={2}>
                <MDAlert color="error" dismissible>
                  <MDTypography variant="body2" color="white">
                    {autoAsignacionError}
                  </MDTypography>
                </MDAlert>
              </MDBox>
            </Grid>
          </Grid>
        )}
        {autoAsignacionMessage && (
          <Grid container justifyContent="center">
            <Grid item xs={12} lg={12}>
              <MDBox pt={2}>
                <MDAlert color="success" dismissible>
                  <MDTypography variant="body2" color="white">
                    {autoAsignacionMessage}
                  </MDTypography>
                </MDAlert>
              </MDBox>
            </Grid>
          </Grid>
        )}
        <FormControl variant="standard" style={{ minWidth: 200, marginRight: 20 }}>
          <InputLabel id="select-tecnico-label">Seleccionar Técnico Responsable</InputLabel>
          <Select
            labelId="select-tecnico-label"
            id="select-tecnico"
            value={selectedItem}
            onChange={(e) => setSelectedItem(e.target.value)}
            label="Seleccionar Técnico"
          >
            {tecnicos.map((tecnico, index) => (
              <MenuItem key={index} value={tecnico.idRepTecnico}>
                {tecnico.nombre + " " + tecnico.apellido}
              </MenuItem>
            ))}
          </Select>
        </FormControl>
        <MDButton variant="gradient" color="success" size="small" onClick={handleAutoasignar}>
          Autoasignar
        </MDButton>
        {errorAlert.show && (
          <Grid container justifyContent="center">
            <Grid item xs={12} lg={12}>
              <MDBox pt={2}>
                <MDAlert color={errorAlert.type} dismissible>
                  <MDTypography variant="body2" color="white">
                    {errorAlert.message}
                  </MDTypography>
                </MDAlert>
              </MDBox>
            </Grid>
          </Grid>
        )}
        <MDBox my={3}>
          <Card>
            {dataTableData.length === 0 ? (
              <MDBox>
                <Card>
                  <p className="contenidoCard"> No posee máquinas sin asignar. </p>
                </Card>
              </MDBox>
            ) : (
              <DataTable
                table={{
                  columns: [
                    //{ Header: "ID", accessor: "id" },
                    { Header: "Id Maquina", accessor: "idMaquina" },
                    { Header: "Descripcion", accessor: "eV_TipoEquipamiento.descripcion" },
                    { Header: "Obra", accessor: "eV_Obra.nombre" },
                    { Header: "Calle", accessor: "eV_Obra.eV_Calle.nombre" },
                    { Header: "Altura", accessor: "eV_Obra.altura" },
                    { Header: "Tipo Obra", accessor: "eV_Obra.eV_TipoObra.descripcion" },
                    {
                      Header: "Edit",
                      accessor: "edit",
                      Cell: ({ row }) => (
                        <Link to={`/MaquinaFE/Edit/${row.original.idMaquina}`}>
                          <MDButton
                            variant="gradient"
                            color="info"
                            onClick={() => handleEdicion(row.original)}
                          >
                            Edicion
                          </MDButton>
                        </Link>
                      ),
                    },
                  ],
                  rows: dataTableData,
                }}
                entriesPerPage={false}
                canSearch
                show
              />
            )}
          </Card>
        </MDBox>
      </DashboardLayout>
    </>
  );
}

MaquinaSinAsignar.propTypes = {
  row: PropTypes.object, // Add this line for 'row' prop
  "row.original": PropTypes.shape({
    id: PropTypes.number,
  }),
};

export default MaquinaSinAsignar;
