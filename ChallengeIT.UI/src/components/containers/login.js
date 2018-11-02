import React, { Component } from "react";
import * as api from "../../apiCaller";
import ChallengeUserPanel from "../challengeUserPanel";
import { Redirect } from "react-router-dom";
import { connect } from "react-redux";
import * as userActions from "../../actions/userActionCreator";
import * as challengeActions from "../../actions/challengeActionCreator";
import { CHALLENGE_STATUS } from "../../constants/challengeStatus";

class Login extends Component {
  constructor(props) {
    super(props);
    const { categoryId } = this.props.match.params;
    this.state = { categoryId, selectedUser: null, filteredUsers: [] };
  }

  render() {
    const user = this.state.selectedUser;       
    if(this.state.hasActiveChallenge){
      return <Redirect to="/playing" />
    }
    if(this.state.redirectToCategoires){
      return <Redirect to="/categories" />
    }
    if(this.state.hasWaitingChallenge){
      return <Redirect to="/playing" />
    }
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

  async selectUser(user) {
    this.props.setCurrentUser(user);
    const activeChallengeResponse = await api.getChallengeByUser(user.id);
    const challenge = activeChallengeResponse.data.data;
    if(challenge.challengeId !== 0){
      this.props.setCurrentChallenge(activeChallengeResponse.data.data);
      if(challenge.status === CHALLENGE_STATUS.WAITING)
      return this.setState({hasWaitingChallenge:true})
      if(challenge.status === CHALLENGE_STATUS.ACCEPTED)
        return this.setState({hasActiveChallenge:true})
    }
    return this.setState({redirectToCategoires: true})
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
  setCurrentUser: userActions.setCurrentUser,
  setCurrentChallenge: challengeActions.setCurrentChallenge
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Login);
