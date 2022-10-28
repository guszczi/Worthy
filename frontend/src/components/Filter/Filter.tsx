import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { setFilter } from "../../redux/slices/filterSlice";
import { RootState } from "../../redux/store";

export const Filter = () => {
    const filter = useSelector(
        (state: RootState) => state.productFilter.filter
    );

    const dispatch = useDispatch();
    
    return (
        <div>
            <input
                type="text"
                onChange={e => dispatch(setFilter(e.target.value))}
                value={filter}
                placeholder="Enter products' name"
            ></input>
        </div>
    )
}
