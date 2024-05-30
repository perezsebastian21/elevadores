// @mui material components
import Grid from "@mui/material/Grid";

// Material Dashboard 2 PRO React components
import MDBox from "components/MDBox";
import { useParams, useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";
import axios from "axios";

// Material Dashboard 2 PRO React examples
import DashboardLayout from "examples/LayoutContainers/DashboardLayout";
import DashboardNavbar from "examples/Navbars/DashboardNavbar";
import Card from "@mui/material/Card";
import MDButton from "components/MDButton";

//Para que el form se pueda utilizar de edicion se tiene que pasar "steps" "apiUrl" "productId" ej: <Formulario steps={steps} apiUrl={apiUrl} productId={id} />
//Para que sea de crear ej: <Formulario steps={steps} apiUrl={apiUrl} />

function AdministracionVer() {
  const { id } = useParams();
  const [administracionData, setAdministracionData] = useState(null);
  const navigate = useNavigate();
  const token = sessionStorage.getItem("token");

  useEffect(() => {
    // Realizar la petición GET al servidor
    axios
      .get(process.env.REACT_APP_API_URL + `administracion/getbyid?id=${id}`, {
        headers: {
          Authorization: `Bearer ${token}`, // Envía el token en los headers
        },
      })
      .then((response) => {
        setAdministracionData(response.data);
      })
      .catch((error) => {
        console.error("Error al obtener los datos:", error);
      });
  }, [id]);

  const handleEditarAdministracion = (idAdministracion) => {
    const productId = idAdministracion;
    const url = `/AdministracionFE/Edit/${productId}`;
    navigate(url);
  };

  return (
    <DashboardLayout>
      <DashboardNavbar />
      {administracionData && (
        <>
          <Card>
            <div>
              <p className="tituloModal">Información de la Administracion</p>
              <div className="contenidoCard">
                <p>ID: {administracionData.idAdministracion}</p>
                <p>Nombre: {administracionData.nombre}</p>
                <p>Telefono: {administracionData.telefono}</p>
                <p>Email: {administracionData.email}</p>
                <p>Departamento: {administracionData.dto}</p>
                <p>Calle: {administracionData.eV_Calle?.nombre ?? "N/A"}</p>
                <p>Altra: {administracionData.altura}</p>
              </div>
              {/* Agrega aquí más campos de acuerdo a la estructura de conservadoraData */}
            </div>
            <MDButton
              onClick={() => handleEditarAdministracion(administracionData.idAdministracion)}
            >
              Editar
            </MDButton>
          </Card>
          <MDBox mt={2}>
            {administracionData.eV_Conservadora.length > 0 ? (
              administracionData.eV_Conservadora.map((conservadora) => (
                <Card key={conservadora.idConservadora} className="card">
                  <p className="tituloModal">Información de Conservadora</p>
                  <Card>
                    <div className="contenidoCard">
                      <p>Conservadora: {conservadora.nombre}</p>
                      <p>Calle: {conservadora.eV_Calle?.nombre ?? "N/A"}</p>
                      <p>Altura: {conservadora.altura}</p>
                      <p>Expediente: {conservadora.expediente}</p>
                    </div>
                    {/* Agrega aquí más información de la máquina si es necesario */}
                  </Card>
                </Card>
              ))
            ) : (
              <MDBox>
                <Card>
                  <div className="contenidoCard">
                    <p>No posee conservadoras registradas.</p>
                  </div>
                </Card>
              </MDBox>
            )}
          </MDBox>
        </>
      )}
    </DashboardLayout>
  );
}

export default AdministracionVer;
