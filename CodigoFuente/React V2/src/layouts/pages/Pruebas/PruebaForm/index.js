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

function PruebaForm() {
  const { id } = useParams();
  const steps = [
    {
      label: "Paso 1",
      fields: [
        { type: "text", label: "Nombre", name: "nombre" },
        { type: "text", label: "Descripcion", name: "descripcion" },
        { type: "text", label: "Source", name: "source" },
        { type: "text", label: "Datasource", name: "datasource" },
      ],
    },
    // {
    //   label: "Paso 2",
    //   fields: [
    //     { type: "text", label: "Descripcion", name: "descripcion" },
    //     { type: "number", label: "Telefono", name: "telefono" },
    //     { type: "text", label: "Email", name: "email" },
    //   ],
    // },
  ];

  const apiUrl = process.env.REACT_APP_API_URL + "CF_Procesos";
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
export default PruebaForm;
