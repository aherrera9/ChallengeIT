import React, { Component } from 'react';
import * as api from '../../apiCaller';
import BottomBar from '../bottomBar';
import { Redirect } from 'react-router-dom';
import waitImg from '../../assets/img/waiting.gif';
import { connect } from "react-redux";
import * as challengeActions  from '../../actions/challengeActionCreator'
import { CHALLENGE_STATUS } from '../../constants/challengeStatus';


class WaitScreen extends Component {
  constructor(props){
    super(props);
    this.state = {challengeCanceled: false};
  }
  render() {
    if(!this.props.currentUser) return <Redirect to="/"/>;
    if(this.state.challengeCanceled) return <Redirect to="/categories"/>;
    if(this.state.challengeAccepted) return <Redirect to="/playing"/>;
    return (
      <div >
        <h1 className="waitingMsg"> We are waiting for <span className="userWating">{this.props.challengedUser.name}</span> to accept your challenge! </h1>
        <img src={waitImg} alt="Waiting" className="waitingImg"/>
        <h1 className="waitingMsg"> It shouldn't be to long... <br/> Once your opponent accepts you will be redirected. </h1>
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

  componentDidMount() {
    //this.timer = setInterval(()=> this.getChallenge(), 1000);
    setTimeout(() => {
      this.setState({challengeAccepted: true});
  }, 15000);
  }

  async getChallenge(){
    // let challengeRes = await api.getChallengeByUser(this.props.currentUser.id);
    // let challenge = challengeRes.data.data;
    // if(challenge.status === CHALLENGE_STATUS.ACCEPTED){
    //   this.setState({challengeAccepted: true});
    //   this.timer=null;
    // }
    
  }
  
}

const mapStateToProps = (state) => ({
  challengedUser: state.users.challengedUser,
  currentUser: state.users.currentUser,
  currentChallenge: state.challenge.currentChallenge
})

const mapDispatchToProps = () => ({
  setCurrentChallenge: challengeActions.setCurrentChallenge,
  setPollTimer: challengeActions.setPollTimer
});

export default connect(mapStateToProps, mapDispatchToProps)(WaitScreen);
