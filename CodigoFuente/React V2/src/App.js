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

import { useState, useEffect } from "react";

// react-router components
import { Routes, Route, Navigate, useLocation } from "react-router-dom";

// @mui material components
import { ThemeProvider } from "@mui/material/styles";
import CssBaseline from "@mui/material/CssBaseline";
import Icon from "@mui/material/Icon";

// Material Dashboard 2 PRO React components
import MDBox from "components/MDBox";

// Material Dashboard 2 PRO React examples
import Sidenav from "examples/Sidenav";
import Configurator from "examples/Configurator";

// Material Dashboard 2 PRO React themes
import theme from "assets/theme";

// Material Dashboard 2 PRO React Dark Mode themes
import themeDark from "assets/theme-dark";

// Material Dashboard 2 PRO React routes
import routes from "routes";

// Material Dashboard 2 PRO React contexts
import { useMaterialUIController, setMiniSidenav, setOpenConfigurator } from "context";

// Images
import logo from "assets/images/Icono.png";
import UsuarioListados from "layouts/pages/Pruebas/UsuarioListados";
import AltaUsuario from "layouts/pages/UsuarioNuevo/AltaUsuario";
import Velocidades from "layouts/pages/Pruebas/Velocidades";
import ResponsableTecnico from "layouts/pages/Pruebas/ResponsableTecnico/index";
import AltaResponsableTecnico from "layouts/pages/Pruebas/ResponsableTecnico/AltaResponsableTecnico";
import Seguro from "layouts/pages/Pruebas/Seguro";
import AltaSeguro from "layouts/pages/Pruebas/Seguro/AltaSeguro";
import AltaVelocidad from "layouts/pages/Pruebas/Velocidades/AltaVelocidad";
import Administracion from "layouts/pages/Pruebas/Administracion/index";
import AltaAdministracion from "layouts/pages/Pruebas/Administracion/AltaAdministracion";
import Equipamiento from "layouts/pages/Pruebas/Equipamiento";
import AltaEquipamiento from "layouts/pages/Pruebas/Equipamiento/AltaEquipamiento";
import AltaConservadora from "layouts/pages/Pruebas/Conservadora/AltaConservadora";
import Conservadora from "layouts/pages/Pruebas/Conservadora/index";
import TipoObra from "layouts/pages/Pruebas/TipoObra/index";
import AltaTipoObra from "layouts/pages/Pruebas/TipoObra/AltaTipoObra";
import ObraTipo from "layouts/pages/Pruebas/ObraTipo/index";
import AltaObraTipo from "layouts/pages/Pruebas/ObraTipo/AltaObraTipo";
import ObraTipoVer from "layouts/pages/Pruebas/ObraTipo/ObraTipoVer";
import ConservadoraVer from "layouts/pages/Pruebas/Conservadora/ConservadoraVer";
import AdministracionVer from "layouts/pages/Pruebas/Administracion/AdministracionVer";
import AltaMaquina from "layouts/pages/Pruebas/Maquina/index";
import MaquinaSinAsignar from "layouts/pages/Pruebas/Maquina/MaquinaSinAsignar";
import AltaCalle from "layouts/pages/Pruebas/Calle/AltaCalle";
import Calle from "layouts/pages/Pruebas/Calle/index";
import AltaRepTecXCons from "layouts/pages/Pruebas/ResponsableTecnico/AltaRepTecXCons";
import ResponsableTecnicoVer from "layouts/pages/Pruebas/ResponsableTecnico/ResposnsableTecnicoVer";
import SignInBasic from "../src/layouts/authentication/sign-in/basic/index";
import Maquina from "layouts/pages/Pruebas/Maquina/ListadoMaquina";

export default function App() {
  const [controller, dispatch] = useMaterialUIController();
  const {
    miniSidenav,
    layout,
    openConfigurator,
    sidenavColor,
    transparentSidenav,
    whiteSidenav,
    darkMode,
  } = controller;
  const [onMouseEnter, setOnMouseEnter] = useState(false);
  const { pathname } = useLocation();

  //Validacion Token

  const isTokenAvailable = () => {
    const token = sessionStorage.getItem("token"); // Cambio a sessionStorage
    return token !== null;
  };

  useEffect(() => {
    const storageEventListener = (event) => {
      if (event.storageArea === sessionStorage && event.key === "token") {
        if (!isTokenAvailable()) {
          sessionStorage.removeItem("token");
          window.location.href = "/authentication/sign-in/basic";
        }
      }
    };
    window.addEventListener("storage", storageEventListener);
    return () => {
      window.removeEventListener("storage", storageEventListener);
    };
  }, []);

  // Open sidenav when mouse enter on mini sidenav
  const handleOnMouseEnter = () => {
    if (miniSidenav && !onMouseEnter) {
      setMiniSidenav(dispatch, false);
      setOnMouseEnter(true);
    }
  };

  // Close sidenav when mouse leave mini sidenav
  const handleOnMouseLeave = () => {
    if (onMouseEnter) {
      setMiniSidenav(dispatch, true);
      setOnMouseEnter(false);
    }
  };

  // Setting page scroll to 0 when changing the route
  useEffect(() => {
    document.documentElement.scrollTop = 0;
    document.scrollingElement.scrollTop = 0;
  }, [pathname]);

  const getRoutes = (allRoutes) =>
    allRoutes.map((route) => {
      if (route.collapse) {
        return getRoutes(route.collapse);
      }

      if (route.route) {
        return <Route exact path={route.route} element={route.component} key={route.key} />;
      }
      return null;
    });

  const RoutesProtegidas = [
    //------------------------Rutas de Alta---------------------------------------------------
    {
      path: "/ResponsableTecnicoFE/Nuevo",
      component: AltaResponsableTecnico,
    },
    {
      path: "/CalleFE/Nuevo",
      component: AltaCalle,
    },
    {
      path: "/TipoEquipamientoFE/Nuevo",
      component: AltaEquipamiento,
    },
    {
      path: "/VelocidadesFE/Nuevo",
      component: AltaVelocidad,
    },
    {
      path: "/SeguroFE/Nuevo",
      component: AltaSeguro,
    },
    {
      path: "/UsuariosListadosFE/NuevoUsuario",
      component: AltaUsuario,
    },
    {
      path: "/AdministracionFE/Nuevo",
      component: AltaAdministracion,
    },
    {
      path: "/ConservadoraFE/Nuevo",
      component: AltaConservadora,
    },
    {
      path: "/TipoObraFE/Nuevo",
      component: AltaTipoObra,
    },
    {
      path: "/ObraTipoFE/Nuevo",
      component: AltaObraTipo,
    },
    {
      path: "/MaquinaFE/Nuevo/:idObra",
      component: AltaMaquina,
    },
    {
      path: "/ConservadoraFE/Tecnico/:idConservadora",
      component: AltaRepTecXCons,
    },
    //-----------------------------Rutas de Listado-----------------------------------------
    {
      path: "/UsuariosListadosFE",
      component: UsuarioListados,
    },
    {
      path: "/CalleFE",
      component: Calle,
    },
    {
      path: "/ResponsableTecnicoFE",
      component: ResponsableTecnico,
    },
    {
      path: "/TipoEquipamientoFE",
      component: Equipamiento,
    },
    {
      path: "/VelocidadesFE",
      component: Velocidades,
    },
    {
      path: "/SeguroFE",
      component: Seguro,
    },
    {
      path: "/AdministracionFE",
      component: Administracion,
    },
    {
      path: "/ConservadoraFE",
      component: Conservadora,
    },
    {
      path: "/TipoObraFE",
      component: TipoObra,
    },
    {
      path: "/ObraTipoFE",
      component: ObraTipo,
    },
    {
      path: "/MaquinaFE",
      component: Maquina,
    },
    //-----------------------------Rutas de Edicion-----------------------------------------
    {
      path: "/AdministracionFE/:id",
      component: AdministracionVer,
    },
    {
      path: "/ConservadoraFE/:id",
      component: ConservadoraVer,
    },
    {
      path: "/ObraTipoFE/:id",
      component: ObraTipoVer,
    },
    {
      path: "/ObraTipoFE/Edit/:id",
      component: AltaObraTipo,
    },
    {
      path: "/MaquinaFE/Edit/:id",
      component: AltaMaquina,
    },
    {
      path: "/ConservadoraFE/Edit/:id",
      component: AltaConservadora,
    },
    {
      path: "/AdministracionFE/Edit/:id",
      component: AltaAdministracion,
    },
    {
      path: "/VelocidadesFE/Edit/:id",
      component: AltaVelocidad,
    },
    {
      path: "/TipoEquipamientoFE/Edit/:id",
      component: AltaEquipamiento,
    },
    {
      path: "/ResponsableTecnicoFE/Edit/:id",
      component: AltaResponsableTecnico,
    },
    {
      path: "/ResponsableTecnicoVerFE/Edit/:id",
      component: ResponsableTecnicoVer,
    },
    {
      path: "/TipoObraFE/Edit/:id",
      component: AltaTipoObra,
    },
    {
      path: "/SeguroFE/Edit/:id",
      component: AltaSeguro,
    },
    {
      path: "/CalleFE/Edit/:id",
      component: AltaCalle,
    },
    {
      path: "/ConservadoraFE/MaquinaSinAsignar/:id",
      component: MaquinaSinAsignar,
    },
  ];

  const login = [
    {
      path: "/authentication/sign-in/basic",
      component: SignInBasic,
    },
  ];
  return (
    <ThemeProvider theme={darkMode ? themeDark : theme}>
      <CssBaseline />
      {layout === "dashboard" && (
        <>
          <Sidenav
            color={sidenavColor}
            brandName="Elevadores"
            brand="https://www.mardelplata.gob.ar/sites/all/themes/mgp/ico/favicon.ico"
            routes={routes}
            onMouseEnter={handleOnMouseEnter}
            onMouseLeave={handleOnMouseLeave}
          />
        </>
      )}
      <Routes>
        {login.map((route) => (
          <Route key={route.path} path={route.path} element={<route.component />} />
        ))}
        <Route path="*" element={<Navigate to="/authentication/sign-in/basic" />} />
        {RoutesProtegidas.map((route) => (
          <Route
            key={route.path}
            path={route.path}
            element={
              isTokenAvailable() ? (
                <route.component />
              ) : (
                <Navigate to="/authentication/sign-in/basic" />
              )
            }
          />
        ))}
      </Routes>
    </ThemeProvider>
  );
}
