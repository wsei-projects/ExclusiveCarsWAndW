import React from 'react'
import ReactDOM from 'react-dom/client'
import { createBrowserRouter, RouterProvider } from 'react-router-dom'
import DefaultLayout from "./layouts/default";
import Home from "./pages/index";

import './index.css'
import 'bootstrap/dist/css/bootstrap.css';

const router = createBrowserRouter([
  {
      path: "/",
      element: <DefaultLayout />,
      children: [
          {
              index: true,
              element: <Home />,
          },
          // {
          //     path: "search",
          //     element: <Search />,
          // },
      ],
  },
]);

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>,
)
