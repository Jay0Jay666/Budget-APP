import "./App.css";
import LayoutComponent from "./Components/Layout/LayoutComponent";
import { BrowserRouter, Routes, Route } from "react-router-dom";

function App() {
  return (
    <div>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<LayoutComponent />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
