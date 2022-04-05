import './App.css';
import Product from "./components/Product/Product";

const products = [
  {
    name: "Мыло 1",
    description: "Описание 1"
  },
  {
    name: "Мыло 2",
    description: "Описание 2"
  },
];

function App() {
  return (
    <div className="App">
      <header className="App-header">
        { products.map(x => (<Product product={x}/>)) }
      </header>
    </div>
  );
}

export default App;