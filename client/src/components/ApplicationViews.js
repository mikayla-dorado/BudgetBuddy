import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { Home } from "./Home"
import { DebtList } from "./debt/DebtList";
import { SavingList } from "./saving/SavingList";


export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={<AuthorizedRoute loggedInUser={loggedInUser}>
            <Home />
          </AuthorizedRoute>
          }
        />


        <Route path="debts">

          <Route index
            element={<AuthorizedRoute loggedInUser={loggedInUser}>
              <DebtList loggedInUser={loggedInUser} />
            </AuthorizedRoute>}
          />
        </Route>
        <Route path="savings">

<Route index
  element={<AuthorizedRoute loggedInUser={loggedInUser}>
    <SavingList loggedInUser={loggedInUser} />
  </AuthorizedRoute>}
/>
</Route>

        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}