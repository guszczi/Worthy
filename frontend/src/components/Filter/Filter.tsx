import { useDispatch, useSelector } from "react-redux";
import React from "react";
import { setFilter } from "../../redux/slices/filterSlice";
import { RootState } from "../../redux/store";
import './Filter.scss'

export const Filter = () => {
  const filter = useSelector(
    (state: RootState) => state.productFilter.filter
  );

  const dispatch = useDispatch();
    
  return (
    <div className="filter-input">
      <input
        type="text"
        onChange={e => dispatch(setFilter(e.target.value))}
        value={filter}
        placeholder="Wyszukaj..."
      ></input>
    </div>
  )
}
