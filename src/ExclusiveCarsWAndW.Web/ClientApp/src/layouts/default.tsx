import { Outlet } from "react-router-dom";
import Navigation from "../components/layout/Navigation";
import Footer from "../components/layout/Footer";

export default function DefaultLayout() {
  return (
    <>
      <Navigation />
      <main className="flex-grow-1 py-4 container">
        <Outlet />
      </main>
      <Footer />
    </>
  );
}
