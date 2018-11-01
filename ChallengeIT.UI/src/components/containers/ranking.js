import React, { Component } from "react";
import * as api from "../../apiCaller";
import { Link, Redirect } from "react-router-dom";
import { connect } from "react-redux";
import * as userActions from "../../actions/userActionCreator";
import BottomBar from "../bottomBar";

class Ranking extends Component {
  constructor(props) {
    super(props);
    this.state = {ranking:[]};
  }

  render() { 
    return (
      <div className="col-12">
      {!this.props.currentCategory && <Redirect to="/categories" />}
        {this.renderTable()}
        <BottomBar>
            <div className="row">
              <div className="col-6">
              <Link to="/categories">
                <button
                  className="btn btn-secondary button-secondary"
                >
                  Go Back
                </button>
              </Link>
              </div>
            </div>
          </BottomBar>
      </div>
    );
  }

  renderTable(){
    return <React.Fragment>
      <h1>Ranking for <span className="highlight">{this.props.currentCategory.name}</span></h1>
      <table className="table">
      <thead>
        <tr>
          <th>Rank</th>
          <th>Name</th>
          <th>W</th>
          <th>L</th>
        </tr>
      </thead>
      <tbody>
        {this.state.ranking.map((row) => <tr>
          <td>{row.rank}</td>
          <td>{row.name}</td>
          <td>{row.wins}</td>
          <td>{row.losses}</td>
        </tr>)}
      </tbody>
      </table>
    </React.Fragment>
  }

  selectUser(user) {
    this.props.setCurrentUser(user);
    this.setState({redirect: true});
  }


  async componentDidMount() {
    const ranking = await api.getRanking(this.props.currentCategory.id);
    this.setState({ ranking: ranking.data.data});
  }
}

const mapStateToProps = (state) => ({
  currentUser: state.users.currentUser,
  currentCategory: state.category.value
});

const mapDispatchToProps = () => ({
  setCurrentUser: userActions.setCurrentUser
});

export default connect(mapStateToProps, mapDispatchToProps)(Ranking);
