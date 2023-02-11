import { configureStore } from "@reduxjs/toolkit";
import filterSliceReducer from "./slices/filterSlice";
import shopsSliceReducer  from "./slices/shopsSlice";
import linksSliceReducer  from "./slices/linksSlice";
import ordersSliceReducer from "./slices/ordersSlice";
import ratingsSliceReducer from "./slices/ratingsSlice"

export const store = configureStore({
  reducer: {
    productFilter: filterSliceReducer,
    allShops: shopsSliceReducer,
    allLinks: linksSliceReducer,
    allOrders: ordersSliceReducer,
    allRatings: ratingsSliceReducer,
  },
})

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;