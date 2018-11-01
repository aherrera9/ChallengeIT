import React, { Component } from 'react';
import * as api from '../../apiCaller';
import ChallengeUserPanel from '../challengeUserPanel';
import BottomBar from '../bottomBar';
import { Redirect } from 'react-router-dom';

class Challenge extends Component {
  constructor(props) {
    super(props);
    const { categoryId } = this.props.match.params;
    this.state = { categoryId, selectedUser: null, filteredUsers: [] };
  }

  render() {
    const user = this.state.selectedUser;
    return (
      <div className="col-12">
        {this.state.goingBack && <Redirect to='/'/>}
        {!user && this.renderUsersList()}
        {user && (
          <ChallengeUserPanel
            {...user}
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
            <li key={user.id} onClick={this.selectUser.bind(this, user.id)}>
              {user.name}
            </li>
          ))}
          {this.state.filteredUsers.length === 0 && <h2>No users found :-(</h2>}
        </ul>
        <BottomBar>
          <div className="row">
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
    this.setState({ selectedUser: null });
  }

  selectUser(userId) {
    let user = this.state.users.find(user => user.id === userId);
    this.setState({
      selectedUser: this.state.users.find(user => user.id === userId)
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
    const users = await api.getUsers();
    this.setState({ users: users.data, filteredUsers: users.data });
  }
}

export default Challenge;
