import {SET_CURRENT_CATEGORY} from '../actions/actionTypes';

const initialState = {
  category: null
};

export default function categoriesReducer(state = initialState, action) {
  switch (action.type) {
    case SET_CURRENT_CATEGORY: {
      return Object.assign({}, state, {value: action.category});
    }
    default: {
      return state;
    }
  }
}