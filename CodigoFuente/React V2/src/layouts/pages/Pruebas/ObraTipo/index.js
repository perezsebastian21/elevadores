import { useState, useEffect } from "react";
import axios from "axios";

// @mui material components
import Card from "@mui/material/Card";
import { Link, useNavigate, useParams } from "react-router-dom";

// Material Dashboard 2 PRO React components
import MDBox from "components/MDBox";
import MDButton from "components/MDButton";
import Grid from "@mui/material/Grid";
import CircularProgress from "@mui/material/CircularProgress";
import MDAlert from "components/MDAlert";
import MDTypography from "components/MDTypography";
import PropTypes from "prop-types";
// Material Dashboard 2 PRO React examples
import DashboardLayout from "examples/LayoutContainers/DashboardLayout";
import DashboardNavbar from "examples/Navbars/DashboardNavbar";
import DataTable from "examples/Tables/DataTable";

function ObraTipo() {
  const navigate = useNavigate();
  const { id } = useParams();
  const [errorAlert, setErrorAlert] = useState({ show: false, message: "", type: "error" });
  const [dataTableData, setDataTableData] = useState();
  const [loading, setLoading] = useState(true);
  const token = sessionStorage.getItem("token");
  useEffect(() => {
    axios
      .get(process.env.REACT_APP_API_URL + "obra/getall", {
        headers: {
          Authorization: `Bearer ${token}`, // Envía el token en los headers
        },
      })
      .then((response) => {
        setDataTableData(response.data);
        setLoading(false); // Marcar la carga como completa
      })
      .catch((error) => {
        setLoading(false);
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
      hour: "2-digit",
      minute: "2-digit",
    };
    return fecha.toLocaleDateString("es-ES", options);
  };

  const handleNuevoTipo = () => {
    navigate("/ObraTipoFE/Nuevo");
  };

  const handleVer = (rowData) => {
    if (rowData && rowData.idObra) {
      const productId = rowData.idObra;
      const url = `/ObraTipoFE/${productId}`;
      navigate(url);
    } else {
      console.error("El objeto rowData o su propiedad 'id' no están definidos.");
    }
  };
  const getActivoText = (activo) => (activo ? "Sí" : "No");
  const displayValue = (value) => (value ? value : "N/A");
  return (
    <>
      <DashboardLayout>
        <DashboardNavbar />
        <MDButton variant="gradient" color="success" onClick={handleNuevoTipo}>
          Agregar
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
        {loading && (
          <Grid container justifyContent="center" pt={10}>
            <CircularProgress color="info" />
          </Grid>
        )}
        {!loading && (
          <MDBox my={3}>
            <Card>
              <DataTable
                table={{
                  columns: [
                    //{ Header: "ID", accessor: "id" },
                    {
                      Header: "Nombre",
                      accessor: "nombre",
                      Cell: ({ value }) => displayValue(value),
                    },
                    {
                      Header: "Calle",
                      accessor: (rowData) => `${rowData.eV_Calle?.nombre} ${rowData.altura}`,
                    },
                    //{ Header: "Calle", accessor: "Calle" },
                    { Header: "Adm", accessor: "eV_Administracion.nombre" },
                    { Header: "Obra", accessor: "eV_TipoObra.descripcion" },
                    {
                      Header: "Activo",
                      accessor: "activo",
                      Cell: ({ value }) => getActivoText(value),
                    },
                    {
                      Header: "Mas Info",
                      accessor: "edit",
                      Cell: ({ row }) => (
                        <MDButton
                          variant="gradient"
                          color="info"
                          onClick={() => handleVer(row.original)}
                        >
                          Mas Info
                        </MDButton>
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
        )}
      </DashboardLayout>
    </>
  );
}

ObraTipo.propTypes = {
  row: PropTypes.object, // Add this line for 'row' prop
  "row.original": PropTypes.shape({
    id: PropTypes.number,
  }),
};

export default ObraTipo;
