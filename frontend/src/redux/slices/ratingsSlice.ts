import { createSlice, PayloadAction } from '@reduxjs/toolkit';

export interface RatingsState {
  ratings: [];
}

const initialState: RatingsState = {
  ratings: [],
}

export const ratingsSlice = createSlice({
  name: 'allRatings',
  initialState,
  reducers: {
    setRatings: (state, action: PayloadAction<[]>) => {
      state.ratings = action.payload;
    }
  }
})

export const { setRatings } = ratingsSlice.actions

export default ratingsSlice.reducer