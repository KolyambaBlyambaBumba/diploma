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
//pedik
function App() {
  const clickHandler = (name) => console.log(`click ${name}`);

  return (
    <div className="App">
      <header className="App-header">
        {
          products.map((x, i) => (
            <div key={i} onClick={() => clickHandler(x.name)}>
              <div>Имя: {x.name}</div>
              <div>Описание: {x.description}</div>
            </div>))
        }
      </header>
    </div>
  );
}

export default App;