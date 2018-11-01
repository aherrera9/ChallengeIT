import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import * as api from '../../apiCaller';

class Home extends Component {
  constructor(props) {
    super(props);
    this.state = { categories: [] };
  }
  render() {
    return (
      <div className="col-12">
        <h1>I want to challenge someone in: </h1>
        <ul className="coolList">
          {this.state.categories.map(category => (
            <Link to={`/challenges/${category.id}`}>
              <li key={category.id}>{category.name}</li>
            </Link>
          ))}
        </ul>
      </div>
    );
  }
  async componentDidMount() {
    const categories = await api.getChallengeCategories();
    this.setState({ categories: categories.data });
  }
}

export default Home;
