// @mui material components
import Grid from "@mui/material/Grid";

// Material Dashboard 2 PRO React components
import MDBox from "components/MDBox";
import { useParams, useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";
import axios from "axios";
import MDButton from "components/MDButton";

// Material Dashboard 2 PRO React examples
import DashboardLayout from "examples/LayoutContainers/DashboardLayout";
import DashboardNavbar from "examples/Navbars/DashboardNavbar";
import Card from "@mui/material/Card";

//Para que el form se pueda utilizar de edicion se tiene que pasar "steps" "apiUrl" "productId" ej: <Formulario steps={steps} apiUrl={apiUrl} productId={id} />
//Para que sea de crear ej: <Formulario steps={steps} apiUrl={apiUrl} />

function ObraTipoVer() {
  const { id } = useParams();
  const [obraData, setObraData] = useState(null);
  const navigate = useNavigate();
  const token = sessionStorage.getItem("token");

  useEffect(() => {
    // Realizar la petición GET al servidor
    axios
      .get(process.env.REACT_APP_API_URL + `obra/getbyid?id=${id}`, {
        headers: {
          Authorization: `Bearer ${token}`, // Envía el token en los headers
        },
      })
      .then((response) => {
        setObraData(response.data);
      })
      .catch((error) => {
        console.error("Error al obtener los datos:", error);
      });
  }, [id]);

  const handleNuevaMaquina = () => {
    navigate(`/MaquinaFE/Nuevo/${obraData.idObra}`);
  };
  const handleEditarMaquina = (idMaquina) => {
    const productId = idMaquina;
    const url = `/MaquinaFE/Edit/${productId}`;
    navigate(url);
  };

  const handleEditarObra = (idObra) => {
    const productId = idObra;
    const url = `/ObraTipoFE/Edit/${productId}`;
    navigate(url);
  };
  return (
    <DashboardLayout>
      <DashboardNavbar />
      {obraData && (
        <>
          <MDBox>
            <Card>
              <p className="tituloModal">{obraData.nombre ?? "N/A"}</p>
              <div className="contenidoCard">
                <p>
                  <b>ID: </b>
                  {obraData.idObra ?? "N/A"}
                </p>
                <p>
                  <b>Calle: </b>
                  {obraData.eV_Calle.nombre ?? "N/A"}
                </p>
                <p>
                  <b>Email: </b>
                  {obraData.email ?? "N/A"}
                </p>
                <p>
                  <b>Expediente: </b>
                  {obraData.expediente ?? "N/A"}
                </p>
                <p>
                  <b>Telefono: </b>
                  {obraData.telefono ?? "N/A"}
                </p>
                <p>
                  <b>Tipo de Obra: </b>
                  {obraData.eV_TipoObra.descripcion ?? "N/A"}
                </p>
                <p>
                  <b>Administracion: </b>
                  {obraData.eV_Administracion.nombre ?? "N/A"}
                </p>
              </div>
              <MDButton onClick={() => handleEditarObra(obraData.idObra)}> Editar </MDButton>
            </Card>
          </MDBox>
          <MDBox mt={2}>
            <MDButton variant="gradient" color="success" onClick={handleNuevaMaquina}>
              Agregar Maquina
            </MDButton>
          </MDBox>
          <MDBox mt={2}>
            {obraData.eV_Maquina.length > 0 ? (
              obraData.eV_Maquina.map((maquina) => (
                <Card key={maquina.idMaquina} className="card">
                  <p className="tituloModal">Información de la Máquina ( {maquina.idMaquina} )</p>
                  <Card>
                    <div className="contenidoCard">
                      <p>
                        <b>Tipo de Equipamiento: </b>
                        {maquina.eV_TipoEquipamiento?.descripcion ?? "N/A"}
                      </p>
                      <p>
                        <b>Número de Serie: </b>
                        {maquina.nroSerie ?? "N/A"}
                      </p>
                      <p>
                        <b>Metros: </b>
                        {maquina.metros ?? "N/A"}
                      </p>
                      <p>
                        <b>Paradas: </b>
                        {maquina.paradas ?? "N/A"}
                      </p>
                      <p>
                        <b>Observaciones: </b>
                        {maquina.observaciones ?? "N/A"}
                      </p>
                      <p>
                        <b>Velocidad: </b>
                        {maquina.eV_Velocidades?.descripcion ?? "N/A"}
                      </p>
                      <p>
                        <b>Rep. Tecnico: </b>
                        {maquina.eV_RepTecnico?.nombre} {maquina.eV_RepTecnico?.apellido}
                      </p>
                      {/* Agrega aquí más información de la máquina si es necesario */}
                    </div>
                    <MDButton onClick={() => handleEditarMaquina(maquina.idMaquina)}>
                      Editar
                    </MDButton>
                  </Card>
                </Card>
              ))
            ) : (
              <MDBox>
                <Card>
                  <p className="contenidoCard">No posee máquinas registradas.</p>
                </Card>
              </MDBox>
            )}
          </MDBox>
        </>
      )}
    </DashboardLayout>
  );
}

export default ObraTipoVer;
