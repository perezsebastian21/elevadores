import { useState, useEffect } from "react";
import axios from "axios";

// @mui material components
import Card from "@mui/material/Card";
import { Link, useNavigate, useParams } from "react-router-dom";

// Material Dashboard 2 PRO React components
import MDBox from "components/MDBox";
import MDButton from "components/MDButton";
import Grid from "@mui/material/Grid";
import MDAlert from "components/MDAlert";
import MDTypography from "components/MDTypography";
import PropTypes from "prop-types";
// Material Dashboard 2 PRO React examples
import DashboardLayout from "examples/LayoutContainers/DashboardLayout";
import DashboardNavbar from "examples/Navbars/DashboardNavbar";
import DataTable from "examples/Tables/DataTable";

function ListadoMaquina() {
  const navigate = useNavigate();
  const { id } = useParams();
  const [errorAlert, setErrorAlert] = useState({ show: false, message: "", type: "error" });
  const [dataTableData, setDataTableData] = useState();
  const token = sessionStorage.getItem("token");
  useEffect(() => {
    axios
      .get(process.env.REACT_APP_API_URL + "maquina/getall", {
        headers: {
          Authorization: `Bearer ${token}`, // Envía el token en los headers
        },
      })
      .then((response) => setDataTableData(response.data))
      /*.then((response) => {
      const obras = response.data.map((obra) => ({
        ...obra,
        Calle: `${obra.idCalle} - ${obra.altura}`,
      }));
      setDataTableData(obras);
    })*/
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
  }, []);

  const formatDate = (dateString) => {
    const fecha = new Date(dateString);
    const options = {
      year: "numeric",
      month: "2-digit",
      day: "2-digit",
    };
    return fecha.toLocaleDateString("es-ES", options);
  };
  const displayValue = (value) => (value ? value : "N/A");
  const handleEditarMaquina = (rowData) => {
    if (rowData && rowData.idRepTecnico) {
      const productId = rowData.idMaquina;
      const url = `/MaquinaFE/Edit/${productId}`;
      navigate(url);
    } else {
      console.error("El objeto rowData o su propiedad 'id' no están definidos.");
    }
  };
  return (
    <>
      <DashboardLayout>
        <DashboardNavbar />
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
            <DataTable
              table={{
                columns: [
                  //{ Header: "ID", accessor: "id" },
                  { Header: "Maquina", accessor: "idMaquina" },
                  {
                    Header: "Tipo Maquina",
                    accessor: "eV_TipoEquipamiento.descripcion",
                    Cell: ({ value }) => displayValue(value),
                  },
                  {
                    Header: "Fecha Fabricacion",
                    accessor: "fechaFabricacion",
                    Cell: ({ row }) => <span>{formatDate(row.original.fechaFabricacion)}</span>,
                  },
                  { Header: "Rep. Tecnico", accessor: "eV_RepTecnico.nombre" },
                  { Header: "Rep. Tecnico", accessor: "eV_RepTecnico.apellido" },
                  //{ Header: "Calle", accessor: "Calle" },
                  {
                    Header: "Mat. Prof",
                    accessor: "eV_RepTecnico.matProf",
                    Cell: ({ value }) => displayValue(value),
                  },
                  {
                    Header: "Mat. Municipal",
                    accessor: "eV_RepTecnico.matMuni",
                    Cell: ({ value }) => displayValue(value),
                  },
                  {
                    Header: "Edit",
                    accessor: "edit",
                    Cell: ({ row }) => (
                      <Link to={`/MaquinaFE/Edit/${row.original.idMaquina}`}>
                        <MDButton
                          variant="gradient"
                          color="info"
                          onClick={() => handleEditarMaquina(row.original)}
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
          </Card>
        </MDBox>
      </DashboardLayout>
    </>
  );
}

ListadoMaquina.propTypes = {
  row: PropTypes.object, // Add this line for 'row' prop
  "row.original": PropTypes.shape({
    id: PropTypes.number,
  }),
};

export default ListadoMaquina;
