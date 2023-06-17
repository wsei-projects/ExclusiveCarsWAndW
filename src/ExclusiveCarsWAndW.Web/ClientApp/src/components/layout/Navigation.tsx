import { NavLink } from "react-router-dom";

export default function Navigation() {
  const navigation = [
    {
      id: 1,
      name: "Home",
      url: "/",
    },
    {
      id: 2,
      name: "Szukaj samochodu",
      url: "/search-car",
    },
  ];

  const loginNavigation = [
    {
      id: 1,
      name: "Logowanie",
      url: "/login",
    },
    {
      id: 2,
      name: "Rejestracja",
      url: "/register",
    },
  ];

  return (
    <header>
      <nav className="navbar navbar-expand-sm navbar-light bg-white border-bottom shadow-sm">
        <div className="container">
          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarTogglerDemo01"
            aria-controls="navbarTogglerDemo01"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarTogglerDemo01">
            <NavLink className="navbar-brand" to="/">
              Exclusive Cars W&W
            </NavLink>
            <div className="d-flex gap-1 ms-auto">
              <ul className="navbar-nav nav-pills gap-1">
                {navigation.map((item) => (
                  <li className="nav-item" key={item.id}>
                    <NavLink
                      className="nav-link"
                      aria-current="page"
                      to={item.url}
                    >
                      {item.name}
                    </NavLink>
                  </li>
                ))}
              </ul>
              <ul className="navbar-nav nav-pills gap-1">
                {loginNavigation.map((item) => (
                  <li className="nav-item" key={item.id}>
                    <NavLink
                      className="nav-link"
                      aria-current="page"
                      to={item.url}
                    >
                      {item.name}
                    </NavLink>
                  </li>
                ))}
              </ul>
            </div>
          </div>
        </div>
      </nav>
    </header>
  );
}
