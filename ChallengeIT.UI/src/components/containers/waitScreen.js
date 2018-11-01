import React, { Component } from 'react';
import * as api from '../../apiCaller';
import BottomBar from '../bottomBar';
import { Redirect } from 'react-router-dom';
import waitImg from '../../assets/img/waiting.gif';
import { connect } from "react-redux";
import * as challengeActions  from '../../actions/challengeActionCreator'


class WaitScreen extends Component {
  constructor(props){
    super(props);
    this.state = {challengeCanceled: false};
  }
  render() {
    if(!this.props.currentUser) return <Redirect to="/"/>;
    if(this.state.challengeCanceled) return <Redirect to="/categories"/>;
    return (
      <div >
        <h1 className="waitingMsg"> We are waiting for <span className="userWating">{this.props.challengedUser.name}</span> to accept your challenge! </h1>
        <img src={waitImg} alt="Waiting" className="waitingImg"/>
        <h1 className="waitingMsg"> It shouldn't be to long... </h1>
        <BottomBar>
        <div className="row">
            <div className="col-6">
              <button className="btn btn-secondary button-secondary" onClick={this.cancelChallenge.bind(this)}>
                Cancel
              </button>
            </div>
          </div>
        </BottomBar>
      </div>
    );
  }
  
  async cancelChallenge(){
    await api.cancelChallenge();
    this.props.setCurrentChallenge(null);
    this.setState({challengeCanceled: true});
  }
}

const mapStateToProps = (state) => ({
  challengedUser: state.users.challengedUser,
  currentUser: state.users.currentUser
})

const mapDispatchToProps = () => ({
  setCurrentChallenge: challengeActions.setCurrentChallenge
});

export default connect(mapStateToProps, mapDispatchToProps)(WaitScreen);
