// @mui material components
import Grid from "@mui/material/Grid";

// Material Dashboard 2 PRO React components
import MDBox from "components/MDBox";
import { useParams } from "react-router-dom";

// Material Dashboard 2 PRO React examples
import DashboardLayout from "examples/LayoutContainers/DashboardLayout";
import DashboardNavbar from "examples/Navbars/DashboardNavbar";
import Footer from "examples/Footer";
import Formulario from "components/Formulario";

//Para que el form se pueda utilizar de edicion se tiene que pasar "steps" "apiUrl" "productId" ej: <Formulario steps={steps} apiUrl={apiUrl} productId={id} />
//Para que sea de crear ej: <Formulario steps={steps} apiUrl={apiUrl} />

function AltaAdministracion() {
  const { id } = useParams();
  let labelTitulo = "Alta Administracion";
  if (id) {
    labelTitulo = "Editar Administracion";
  }
  const steps = [
    {
      label: labelTitulo,
      fields: [
        { type: "text", label: "Nombre", name: "nombre", required: true },
        {
          type: "select",
          label: "Calle",
          name: "idCalle",
          apiUrl: process.env.REACT_APP_API_URL + "calle/GetAll",
          valueField: "idCalle", // Nombre del campo del valor
          optionField: "nombre",
          required: true,
        },
        { type: "text", label: "Altura", name: "altura", required: true },
        { type: "numbre", label: "Telefono", name: "telefono" },
        { type: "text", label: "Departamento", name: "dto" },
        { type: "checkbox", label: "Habilitado", name: "habilitado" },
        { type: "checkbox", label: "Activo", name: "activo" },
      ],
    },
  ];

  const apiUrl = process.env.REACT_APP_API_URL + `administracion`;
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

export default AltaAdministracion;
