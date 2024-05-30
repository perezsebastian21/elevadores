import { useState, useEffect } from "react";
import axios from "axios";

// @mui material components
import Card from "@mui/material/Card";
import { Link, useNavigate } from "react-router-dom";

// Material Dashboard 2 PRO React components
import MDBox from "components/MDBox";
import MDButton from "components/MDButton";
import PropTypes from "prop-types";
// Material Dashboard 2 PRO React examples
import DashboardLayout from "examples/LayoutContainers/DashboardLayout";
import DashboardNavbar from "examples/Navbars/DashboardNavbar";
import Footer from "examples/Footer";
import DataTable from "examples/Tables/DataTable";
function Configurador() {
  const navigate = useNavigate();
  const [dataTableData, setDataTableData] = useState();
  useEffect(() => {
    axios
      .get(process.env.REACT_APP_API_URL + "CF_Grupos")
      .then((response) => setDataTableData(response.data))
      .catch((error) => console.error("Error al obtener los datos:", error));
  }, []);

  const handleEdicion = (rowData) => {
    const grupoId = rowData.id;
    const url = `/Configurador/${grupoId}`;
    navigate(url);
  };

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

  return (
    <DashboardLayout>
      <DashboardNavbar />
      <MDBox my={3}>
        <Card>
          <DataTable
            table={{
              columns: [
                //{ Header: "ID", accessor: "id" },
                { Header: "Nombre", accessor: "nombre" },
                { Header: "Descripcion", accessor: "descripcion" },
                {
                  Header: "Actualizado",
                  accessor: "fechaActualización",
                  Cell: ({ row }) => <span>{formatDate(row.original.fechaActualización)}</span>,
                },
                {
                  Header: "",
                  accessor: "edit",
                  Cell: ({ row }) => (
                    <Link to={`/Configurador/${row.original.id}`}>
                      <MDButton
                        variant="gradient"
                        color="info"
                        onClick={() => handleEdicion(row.original)}
                      >
                        Ver
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
  );
}

Configurador.propTypes = {
  row: PropTypes.object, // Add this line for 'row' prop
  "row.original": PropTypes.shape({
    id: PropTypes.number,
  }),
};

export default Configurador;
