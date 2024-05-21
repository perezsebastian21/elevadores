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

/** 
  All of the routes for the Material Dashboard 2 PRO React are added here,
  You can add a new route, customize the routes and delete the routes here.

  Once you add a new route on this file it will be visible automatically on
  the Sidenav.

  For adding a new route you can follow the existing routes in the routes array.
  1. The `type` key with the `collapse` value is used for a route.
  2. The `type` key with the `title` value is used for a title inside the Sidenav. 
  3. The `type` key with the `divider` value is used for a divider between Sidenav items.
  4. The `name` key is used for the name of the route on the Sidenav.
  5. The `key` key is used for the key of the route (It will help you with the key prop inside a loop).
  6. The `icon` key is used for the icon of the route on the Sidenav, you have to add a node.
  7. The `collapse` key is used for making a collapsible item on the Sidenav that contains other routes
  inside (nested routes), you need to pass the nested routes inside an array as a value for the `collapse` key.
  8. The `route` key is used to store the route location which is used for the react router.
  9. The `href` key is used to store the external links location.
  10. The `title` key is only for the item with the type of `title` and its used for the title text on the Sidenav.
  10. The `component` key is used to store the component of its route.
*/

// Material Dashboard 2 PRO React layouts
import ProfileOverview from "layouts/pages/profile/profile-overview";
import Settings from "layouts/pages/account/settings";
import SignInBasic from "layouts/authentication/sign-in/basic";
// Material Dashboard 2 PRO React components
import MDAvatar from "components/MDAvatar";

// @mui icons
import Icon from "@mui/material/Icon";

// Images
import UsuarioListados from "layouts/pages/Pruebas/UsuarioListados";
import Velocidades from "layouts/pages/Pruebas/Velocidades";
import ResponsableTecnico from "layouts/pages/Pruebas/ResponsableTecnico";
import TipoObra from "layouts/pages/Pruebas/TipoObra/index";
import Seguro from "layouts/pages/Pruebas/Seguro";
import Administracion from "layouts/pages/Pruebas/Administracion";
import Equipamiento from "layouts/pages/Pruebas/Equipamiento/index";
import Conservadora from "layouts/pages/Pruebas/Conservadora/index";
import ObraTipo from "layouts/pages/Pruebas/ObraTipo";
import ListadoMaquina from "layouts/pages/Pruebas/Maquina/ListadoMaquina";
import Calle from "layouts/pages/Pruebas/Calle/index";

const routes = [
  {
    type: "collapse",
    icon: <Icon>apartment</Icon>,
    name: "Obra",
    key: "obra",
    collapse: [
      {
        name: "Listado Obra",
        key: "listadoObra",
        route: "/ObraTipoFE",
        component: <ObraTipo />,
      },
    ],
  },
  { type: "divider", key: "divider-0" },
  {
    type: "collapse",
    icon: <Icon>villa</Icon>,
    name: "Conservadora",
    key: "conservadora",
    collapse: [
      {
        name: "Listado Conservadora",
        key: "listadoConservadora",
        route: "/ConservadoraFE",
        component: <Conservadora />,
      },
    ],
  },
  { type: "divider", key: "divider-1" },
  {
    type: "collapse",
    icon: <Icon>engineering</Icon>,
    name: "Rep. Tecnico",
    key: "ResponsableTecnicoFE",
    collapse: [
      {
        name: "Listado Rep. Tecnico",
        key: "RepTecnico",
        route: "/ResponsableTecnicoFE",
        component: <ResponsableTecnico />,
      },
    ],
  },
  { type: "divider", key: "divider-2" },
  {
    type: "collapse",
    icon: <Icon>group</Icon>,
    name: "Administracion",
    key: "Administracion",
    collapse: [
      {
        name: "Listado Adm",
        key: "Administraciones",
        route: "/AdministracionFE",
        component: <Administracion />,
      },
    ],
  },
  { type: "divider", key: "divider-3" },
  {
    type: "collapse",
    icon: <Icon>admin_panel_settings</Icon>,
    name: "Seguro",
    key: "Seguro",
    collapse: [
      {
        name: "Listado Seguro",
        key: "Seguro",
        route: "/SeguroFE",
        component: <Seguro />,
      },
    ],
  },
  { type: "divider", key: "divider-4" },
  {
    type: "collapse",
    icon: <Icon fontSize="medium">candlestick_chart</Icon>,
    name: "Parametricas",
    key: "Parametricas",
    collapse: [
      {
        name: "Tipo de Equipamiento",
        key: "TipoEquipamiento",
        route: "/TipoEquipamientoFE",
        component: <Equipamiento />,
      },
      {
        name: "Velocidades",
        key: "Velocidades",
        route: "/VelocidadesFE",
        component: <Velocidades />,
      },
      {
        name: "Calle",
        key: "calle",
        route: "/CalleFE",
        component: <Calle />,
      },
      {
        name: "Tipo Obra",
        key: "TipoObra",
        route: "/TipoObraFE",
        component: <TipoObra />,
      },
      {
        name: "Listado Maquinas",
        key: "ListadoMaquina",
        route: "/MaquinaFE",
        component: <ListadoMaquina />,
      },
    ],
  },
  { type: "divider", key: "divider-5" },
  {
    type: "collapse",
    icon: <MDAvatar size="sm" />,
    name: "Usuarios",
    key: "Usuarios",
    collapse: [
      {
        name: "Listado Usuarios",
        key: "ListUsuarios",
        route: "/UsuariosListadosFE",
        component: <UsuarioListados />,
      },
    ],
  },
];

export default routes;
