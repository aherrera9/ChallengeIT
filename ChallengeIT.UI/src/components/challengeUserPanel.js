import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';
import * as api from '../apiCaller';
import BottomBar from './bottomBar';
import { connect } from "react-redux";
import * as challengeActions from '../actions/challengeActionCreator';


class ChallengeUserPanel extends Component {
  constructor(props){
    super(props);
    this.state={}
  }
  render() { 
    if(!this.props.currentUser){
      return <Redirect to="/" />
    }
    if(this.state.redirect){
      return <Redirect to="/wait" />
    }
    return (
      <div className="col-12">
        <h2>You are about to challenge: </h2>
        <h1 className="challengeUserName">{this.props.challengedUser.name}</h1>
        <h2>To play </h2>
         <h1 className="challengeUserName">{this.props.category.name}</h1> 
        <h2>Are you ready? </h2>
          <BottomBar>
            <div className="row">
            <div className="col-6">
              <button className="btn btn-primary button-main" onClick={this.challengePlayer.bind(this)}>
                Challenge!
              </button>
            </div>
            <div className="col-6">
              <button className="btn btn-secondary button-secondary" onClick={this.props.goBackFunction}>Cancel</button>
            </div>
            </div>
          </BottomBar>
      </div>
    );
  }

  async challengePlayer() {
    let challenge = await api.challengePlayer()
    this.props.setCurrentChallenge(challenge.data);
    this.setState({redirect: true});
  }
}

const mapDispatchToProps = () => ({
  setCurrentChallenge : challengeActions.setCurrentChallenge
});

const mapStateToProps = (state) => ({
  currentUser: state.users.currentUser,
  challengedUser: state.users.challengedUser,
  category: state.category.value
});

export default connect(mapStateToProps, mapDispatchToProps)(ChallengeUserPanel);
