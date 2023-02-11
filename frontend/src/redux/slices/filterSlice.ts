import { createSlice } from '@reduxjs/toolkit'
import type { PayloadAction } from '@reduxjs/toolkit'

export interface FilterState {
  filter: string
}

const initialState: FilterState = {
  filter: '',
}

export const filterSlice = createSlice({
  name: 'productFilter',
  initialState,
  reducers: {
    setFilter: (state, action: PayloadAction<string>) => {
      state.filter = action.payload
    }
  },

})

export const { setFilter } = filterSlice.actions

export default filterSlice.reducer