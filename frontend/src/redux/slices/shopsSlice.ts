import { createSlice, PayloadAction } from '@reduxjs/toolkit';

export interface ShopsState {
  shops: [];
}

const initialState: ShopsState = {
  shops: [],
}

export const shopsSlice = createSlice({
  name: 'allShops',
  initialState,
  reducers: {
    setShops: (state, action: PayloadAction<[]>) => {
      state.shops = action.payload;
    }
  }
})

export const { setShops } = shopsSlice.actions

export default shopsSlice.reducer