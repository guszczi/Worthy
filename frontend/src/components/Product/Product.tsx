import { useState } from "react";
import { useSelector } from "react-redux";
import { RootState } from "../../redux/store";

const initialProducts = [
    {name: 'jeden', cost: 10},
    {name: 'dwa', cost: 10},
    {name: 'trzy', cost: 10},
    {name: 'cztery', cost: 10}
];

export const Product = () => {
    const [products] = useState(initialProducts);

    const filterBy = useSelector(
        (state: RootState) => state.productFilter.filter
    );
    
    return (
        <div>
            {products
                .filter(product =>
                    filterBy ? product.name.includes(filterBy) : true    
                )
                .map(product => (
                    <div key={product.name}>
                    {product.name} - {product.cost}
                    </div>
            ))}
        </div>
    )
}