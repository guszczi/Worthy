import { createSlice, PayloadAction } from '@reduxjs/toolkit';

export interface OrdersState {
  orders: [];
}

const initialState: OrdersState = {
  orders: [],
}

export const ordersSlice = createSlice({
  name: 'allOrders',
  initialState,
  reducers: {
    setOrders: (state, action: PayloadAction<[]>) => {
      state.orders = action.payload;
    }
  }
})

export const { setOrders } = ordersSlice.actions

export default ordersSlice.reducer