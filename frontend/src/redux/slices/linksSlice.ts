import { createSlice } from '@reduxjs/toolkit'
import type { PayloadAction } from '@reduxjs/toolkit'

export interface LinksState {
  links: [],
}

const initialState: LinksState = {
  links: [],
}

export const linksSlice = createSlice({
  name: 'allLinks',
  initialState,
  reducers: {
    setLinks: (state, action: PayloadAction<[]>) => {
      state.links = action.payload
    }
  },

})

export const { setLinks } = linksSlice.actions

export default linksSlice.reducer