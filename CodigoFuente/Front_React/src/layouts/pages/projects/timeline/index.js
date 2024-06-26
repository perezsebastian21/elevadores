/**
=========================================================
* Material Dashboard 2 PRO React - v2.2.0
=========================================================

* Product Page: https://www.creative-tim.com/product/material-dashboard-pro-react
* Copyright 2023 Creative Tim (https://www.creative-tim.com)

Coded by www.creative-tim.com

 =========================================================

* The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
*/

// @mui material components
import Grid from "@mui/material/Grid";

// Material Dashboard 2 PRO React components
import MDBox from "components/MDBox";

// Material Dashboard 2 PRO React examples
import DashboardLayout from "examples/LayoutContainers/DashboardLayout";
import DashboardNavbar from "examples/Navbars/DashboardNavbar";
import Footer from "examples/Footer";
import TimelineList from "examples/Timeline/TimelineList";
import TimelineItem from "examples/Timeline/TimelineItem";

// Data
import timelineData from "layouts/pages/projects/timeline/data/timelineData";
import Formulario from "components/Formulario";

function Timeline() {
  const steps = [
    {
      label: "Paso 1",
      fields: [
        { type: "text", label: "Hola hola", name: "hola hola" },
        { type: "text", label: "Qonda", name: "Qonda" },
        { type: "number", label: "DNI", name: "dni" },
        { type: "email", label: "Email", name: "email" },
      ],
    },
    {
      label: "Paso 2",
      fields: [
        { type: "text", label: "Nombre", name: "nombre" },
        { type: "text", label: "Apellido", name: "apellido" },
        { type: "number", label: "Telefono", name: "telefono" },
        { type: "text", label: "Direccion", name: "Direccion" },
      ],
    },
  ];
  const renderTimelineItems = timelineData.map(
    ({ color, icon, title, dateTime, description, badges, lastItem }) => (
      <TimelineItem
        key={title + color}
        color={color}
        icon={icon}
        title={title}
        dateTime={dateTime}
        description={description}
        badges={badges}
        lastItem={lastItem}
      />
    )
  );
  const apiUrl = "URL_DE_Timeline";
  return (
    <DashboardLayout>
      <DashboardNavbar />
      <MDBox my={3}>
        <Grid container spacing={3}>
          <Grid item xs={12} lg={6}>
            <TimelineList title="Timeline with dotted line">{renderTimelineItems}</TimelineList>
          </Grid>
          <Grid item xs={12} lg={6}>
            <TimelineList title="Timeline with dotted line" dark>
              {renderTimelineItems}
            </TimelineList>
          </Grid>
          <Formulario steps={steps} apiUrl={apiUrl} />
        </Grid>
      </MDBox>
    </DashboardLayout>
  );
}

export default Timeline;
