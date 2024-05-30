// @mui material components
import Grid from "@mui/material/Grid";

// Material Dashboard 2 PRO React components
import MDBox from "components/MDBox";
import { useParams } from "react-router-dom";

// Material Dashboard 2 PRO React examples
import DashboardLayout from "examples/LayoutContainers/DashboardLayout";
import DashboardNavbar from "examples/Navbars/DashboardNavbar";
import Formulario from "components/Formulario";

//Para que el form se pueda utilizar de edicion se tiene que pasar "steps" "apiUrl" "productId" ej: <Formulario steps={steps} apiUrl={apiUrl} productId={id} />
//Para que sea de crear ej: <Formulario steps={steps} apiUrl={apiUrl} />

function AltaResponsableTecnico() {
  const { id } = useParams();

  let labelTitulo = "Alta Responsable Tecnico";
  if (id) {
    labelTitulo = "Editar Responsable Tecnico";
  }
  const steps = [
    {
      label: labelTitulo,
      fields: [
        { type: "text", label: "Nombre", name: "nombre", required: true },
        { type: "text", label: "Apellido", name: "apellido", required: true },
        { type: "text", label: "Email", name: "email" },
        { type: "text", label: "Telefono", name: "telefono" },
        {
          type: "select",
          label: "Calle",
          name: "idCalle",
          apiUrl: process.env.REACT_APP_API_URL + "calle/GetAll",
          valueField: "idCalle", // Nombre del campo del valor
          optionField: "nombre",
        },
        { type: "number", label: "Altura", name: "altura" },
        { type: "text", label: "Matricula Prof.", name: "matProf" },
        { type: "text", label: "Matricula Muni.", name: "matMuni" },
        { type: "checkbox", label: "Habilitado", name: "habilitado" },
        { type: "checkbox", label: "Activo", name: "activo" },
      ],
    },
  ];

  const apiUrl = process.env.REACT_APP_API_URL + `repTecnico`;
  return (
    <DashboardLayout>
      <DashboardNavbar />
      <MDBox py={3} mb={20} height="65vh">
        <Grid container justifyContent="center" alignItems="center" sx={{ height: "100%", mt: 8 }}>
          <Grid item xs={12} lg={10}>
            <Formulario steps={steps} apiUrl={apiUrl} productId={id} />
          </Grid>
        </Grid>
      </MDBox>
    </DashboardLayout>
  );
}

export default AltaResponsableTecnico;
