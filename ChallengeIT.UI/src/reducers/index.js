import {combineReducers} from 'redux';
import userReducer from './userReducer';
import challengeReducer from './userReducer';
import categoriesReducer from './categoriesReducer';


const rootReducer = combineReducers({
  users: userReducer,
  challenge: challengeReducer,
  category: categoriesReducer
});

export default rootReducer;
