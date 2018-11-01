import React, { Component } from "react";
import * as api from "../../apiCaller";
import ChallengeUserPanel from "../challengeUserPanel";
import { Redirect } from "react-router-dom";
import { connect } from "react-redux";
import * as userActions from "../../actions/userActionCreator";

class Login extends Component {
  constructor(props) {
    super(props);
    const { categoryId } = this.props.match.params;
    this.state = { categoryId, selectedUser: null, filteredUsers: [] };
  }

  render() {
    const user = this.state.selectedUser;
    return (
      <div className="col-12">
        {this.state.redirect && <Redirect to="/categories" />}
        {this.renderUsersList()}
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
        <h1>Please identify yourself:</h1>
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
      </React.Fragment>
    );
  }

  selectUser(user) {
    this.props.setCurrentUser(user);
    this.setState({redirect: true});
  }

  handleUserInput(e) {
    let usersCopy = Object.assign([], this.state.users);
    if (e.target.value !== "") {
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
    this.setState({ users: users.data.data, filteredUsers: users.data.data });
  }
}

const mapStateToProps = (state) => ({
  currentUser: state.users.currentUser
});

const mapDispatchToProps = {
  setCurrentUser: userActions.setCurrentUser
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Login);
