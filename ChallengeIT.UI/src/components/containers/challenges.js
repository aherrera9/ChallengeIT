import React, { Component } from 'react';
import * as api from '../../apiCaller';
import ChallengeUserPanel from '../challengeUserPanel';
import BottomBar from '../bottomBar';
import { Redirect, Link } from 'react-router-dom';
import {connect} from 'react-redux';
import * as userActions from '../../actions/userActionCreator';

class Challenges extends Component {
  constructor(props) {
    super(props);
    const { categoryId } = this.props.match.params;
    this.state = { categoryId, selectedUser: null, filteredUsers: [] };
  }

  render() {
    const challengeUserSelected = this.state.challengeUserSelected;
    return (
      <div className="col-12">
        {this.state.goingBack && <Redirect to='/categories'/>}
        {!this.props.currentUser && <Redirect to='/'/>}
        {!challengeUserSelected && this.renderUsersList()}
        {challengeUserSelected && (
          <ChallengeUserPanel
            goBackFunction={this.removeSelectedUser.bind(this)}
          />
        )}
      </div>
    );
  }

  renderUsersList() {
    return (
      <React.Fragment>
        <h1>Who do you want to challenge?</h1>
        <input
          type="text"
          className="userInput"
          placeholder="Write to filter.."
          onChange={this.handleUserInput.bind(this)}
        />
        <ul className="coolList">
          {this.state.filteredUsers.map(user => (
            <li key={Math.random()} onClick={this.selectUser.bind(this, user)}>
              {user.name}
            </li>
          ))}
          {this.state.filteredUsers.length === 0 && <h2>No users found :-(</h2>}
        </ul>
        <BottomBar>
          <div className="row">
          <div className="col-6">
          <Link to="/ranking">
                <button
                  className="btn btn-primary button-main"
                  onClick={this.goBack.bind(this)}
                >
                  Ranking
                </button>
              </Link>
            </div>
            <div className="col-6">
              <button className="btn btn-secondary button-secondary" onClick={this.goBack.bind(this)}>
                Go Back
              </button>
            </div>
          </div>
        </BottomBar>
      </React.Fragment>
    );
  }

  goBack() {
    this.setState({goingBack: true})
  }

  removeSelectedUser() {
    this.props.setChallengedUser(null);
    this.setState({
      challengeUserSelected: false
    });
  }

  selectUser(user) {
    this.props.setChallengedUser(user);
    this.setState({
      challengeUserSelected: true
    });
  }

  handleUserInput(e) {
    let usersCopy = Object.assign([], this.state.users);
    if (e.target.value !== '') {
      let filtered = usersCopy.filter(
        user =>
          user.name.toLowerCase().indexOf(e.target.value.toLowerCase()) > -1
      );
      this.setState({ filteredUsers: filtered });
    } else {
      this.setState({ filteredUsers: usersCopy });
    }
  }

   async componentDidMount() {
     if(!this.props.currentUser) return;
    const users = await api.getUsers();
    let filtered = users.data.data.filter(
      user => user.id !== this.props.currentUser.id
    );
    this.setState({ users: filtered, filteredUsers: filtered });
  }
}

const mapStateToProps = (state) => ({
  currentUser : state.users.currentUser,
  currentCategory: state.category.value
});

const mapDispatchToProps = {
  setChallengedUser: userActions.setChallengedUser
};

export default connect(mapStateToProps, mapDispatchToProps)(Challenges);
