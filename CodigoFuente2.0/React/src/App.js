import React, { useEffect } from "react";
import {
  BrowserRouter as Router,
  Route,
  Switch,
  Redirect,
} from "react-router-dom";
import LoginPage from "./views/Pages/LoginPage";
import { Provider } from "react-redux";
import store from "./store";
import AuthProvider from "./utils/authProvider";
import oauth, { loadUserFromStorage } from "./services/oauth";
import PrivateRoute from "./utils/protectedRoute";

// core components
import AuthLayout from "layouts/Auth.js";
import RtlLayout from "layouts/RTL.js";
import AdminLayout from "layouts/Admin.js";

function App() {
  useEffect(() => {
    // fetch current user from cookies
    loadUserFromStorage(store);
  }, []);

  return (
    <Provider store={store}>
      <AuthProvider userManager={oauth} store={store}>
        <Router>
          <Switch>
            <PrivateRoute path="/rtl" component={RtlLayout} />
            <PrivateRoute path="/admin" component={AdminLayout} />

            <Route path="/login-page" component={LoginPage} />
            <Route path="/auth" component={AuthLayout} />
            <Redirect from="/" to="/admin/dashboard" />
          </Switch>
        </Router>
      </AuthProvider>
    </Provider>
  );
}

export default App;
