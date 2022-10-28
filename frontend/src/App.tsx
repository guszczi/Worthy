import './App.scss';
import { Filter } from './components/Filter/Filter';
import { Product } from './components/Product/Product';

function App() {
  return (
    <div className="App">
      <Filter />
      <Product />
    </div>
  );
}

export default App;
