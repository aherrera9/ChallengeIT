import React, { Component } from "react";
import { Redirect } from "react-router-dom";
import * as api from "../../apiCaller";
import { connect } from "react-redux";
import BottomBar from "../bottomBar";
import * as categoriesActions from "../../actions/categoriesActionCreator";

class Categories extends Component {
  constructor(props) {
    super(props);
    this.state = { categories: [] };
  }
  render() {
    if (!this.props.currentUser || this.state.goBack) {
      return <Redirect to="/" />;
    }
    
    if(this.state.redirect){
      return <Redirect to="/challenges" />
    }
    return (
      <div className="col-12">
        <h1>
          Hi{" "}
          <span className="categoriesUserName">
            {this.props.currentUser.name}
          </span>
          ! <br />
          What do you feel like playing today?{" "}
        </h1>
        <ul className="coolList">
          {this.state.categories.map(category => (
              <li key={Math.random()} onClick={this.selectCategory.bind(this, category)}>{category.name}</li>
          ))}
        </ul>
          <BottomBar>
            <div className="row">
              <div className="col-6">
                <button
                  className="btn btn-secondary button-secondary"
                  onClick={this.goBack.bind(this)}
                >
                  Go Back
                </button>
              </div>
            </div>
          </BottomBar>
      </div>
    );
  }
  selectCategory(category){
    this.props.setCurrentCategory(category);
    this.setState({redirect: true});
  }

  async componentDidMount() {
    const categories = await api.getChallengeCategories();
    this.setState({ categories: categories.data });
  }
  goBack() {
    this.setState({ goBack: true });
  }
}

const mapStateToProps = state => {
  return {
    currentUser: state.users.currentUser
  };
};

const mapDispatchToProps = {
  setCurrentCategory: categoriesActions.setCurrentCategory
};

export default connect(mapStateToProps, mapDispatchToProps)(Categories);
