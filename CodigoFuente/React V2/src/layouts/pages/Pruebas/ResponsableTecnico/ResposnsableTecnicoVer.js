// @mui material components
import Grid from "@mui/material/Grid";
import PropTypes from "prop-types";

// Material Dashboard 2 PRO React components
import MDBox from "components/MDBox";
import { useParams, useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";
import axios from "axios";

// Material Dashboard 2 PRO React examples
import DashboardLayout from "examples/LayoutContainers/DashboardLayout";
import DashboardNavbar from "examples/Navbars/DashboardNavbar";
import Card from "@mui/material/Card";
import DataTable from "examples/Tables/DataTable";
import MDButton from "components/MDButton";

//Para que el form se pueda utilizar de edicion se tiene que pasar "steps" "apiUrl" "productId" ej: <Formulario steps={steps} apiUrl={apiUrl} productId={id} />
//Para que sea de crear ej: <Formulario steps={steps} apiUrl={apiUrl} />

function ResponsableTecnicoVer() {
  const { id } = useParams();
  const [respTecnicoData, setRespTecnicoData] = useState(null);
  const [dataTableMaquinasData, setDataTableMaquinasData] = useState([]);
  const navigate = useNavigate();
  const token = sessionStorage.getItem("token");
  useEffect(() => {
    axios
      .get(process.env.REACT_APP_API_URL + `repTecnico/getbyid?id=${id}`, {
        headers: {
          Authorization: `Bearer ${token}`, // Envía el token en los headers
        },
      })
      .then((response) => {
        setRespTecnicoData(response.data);
        const maquinasData = response.data.eV_Maquina.map((maquina) => ({
          ...maquina,
          Calle: `${maquina.eV_Obra.eV_Calle.nombre} ${maquina.eV_Obra.altura}`,
        }));
        setDataTableMaquinasData(maquinasData);
      })
      .catch((error) => {
        console.error("Error al obtener los datos:", error);
      });
  }, [id]);

  const handleEditarResponsableTecnico = (idConservadora) => {
    const productId = idConservadora;
    const url = `/ResponsableTecnicoFE/Edit/${productId}`;
    navigate(url);
  };

  const handleEditarMaquina = (idMaquina) => {
    const productId = idMaquina;
    const url = `/MaquinaFE/Edit/${productId}`;
    navigate(url);
  };
  return (
    <DashboardLayout>
      <DashboardNavbar />
      {respTecnicoData && (
        <>
          <MDBox>
            <Card>
              <div>
                <p className="tituloModal">Información Responsable Tecnico</p>
                <div className="contenidoCard">
                  <p>
                    Apellido y Nombre:
                    {respTecnicoData.Apellido} {respTecnicoData.nombre}
                  </p>
                  <p>
                    Calle:
                    {respTecnicoData.eV_Calle?.nombre} {respTecnicoData.altura}
                  </p>
                  <p>Matricula Municipal: {respTecnicoData.matMuni}</p>
                  <p>Matricula Profesional: {respTecnicoData.matProf}</p>
                  <p>Telefono: {respTecnicoData.telefono}</p>
                  <p>Email: {respTecnicoData.email}</p>
                  <p>Departamento: {respTecnicoData.dto}</p>
                </div>
                {/* Agrega aquí más campos de acuerdo a la estructura de conservadoraData */}
              </div>
              <MDButton
                onClick={() => handleEditarResponsableTecnico(respTecnicoData.idRepTecnico)}
              >
                Editar
              </MDButton>
            </Card>
          </MDBox>
          <MDBox mt={2}>
            {dataTableMaquinasData.length > 0 ? (
              <>
                <MDBox mb={1}>
                  <Card sx={{ justifyContent: "space-between" }}>
                    <p className="tituloModalMQ">
                      Informacion Maquinas ({respTecnicoData.eV_Maquina.length})
                    </p>
                  </Card>
                </MDBox>
                <DataTable
                  table={{
                    columns: [
                      { Header: "Id Maquina", accessor: "idMaquina" },
                      { Header: "Calle", accessor: "Calle" },
                      { Header: "Nombre Obra", accessor: "eV_Obra.nombre" }, // Accede al nombre de la obra dentro de cada máquina
                      { Header: "Tipo Equipamiento", accessor: "eV_TipoEquipamiento.descripcion" }, // Ajusta según la estructura de tus datos
                      {
                        Header: "",
                        accessor: "edit",
                        Cell: ({ row }) => (
                          <MDButton
                            variant="gradient"
                            color="info"
                            onClick={() => handleEditarMaquina(row.values.idMaquina)}
                          >
                            Edicion
                          </MDButton>
                        ),
                      },
                    ],
                    rows: dataTableMaquinasData,
                  }}
                  entriesPerPage={false}
                  canSearch
                  show
                />
              </>
            ) : (
              <MDBox>
                <Card>
                  <p className="contenidoCard"> No posee máquinas asignadas. </p>
                </Card>
              </MDBox>
            )}
          </MDBox>
        </>
      )}
    </DashboardLayout>
  );
}
ResponsableTecnicoVer.propTypes = {
  row: PropTypes.object, // Add this line for 'row' prop
  "row.original": PropTypes.shape({
    id: PropTypes.number,
  }),
};
export default ResponsableTecnicoVer;
