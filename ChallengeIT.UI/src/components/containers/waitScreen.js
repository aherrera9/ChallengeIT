import React, { Component } from 'react';
import * as api from '../../apiCaller';
import ChallengeUserPanel from '../challengeUserPanel';
import BottomBar from '../bottomBar';
import { Redirect } from 'react-router-dom';
import waitImg from '../../assets/img/waiting.gif';

class WaitScreen extends Component {
  constructor(props){
    super(props);
    this.state = {challengeCanceled: false};
  }
  render() {
    let styles = {
      backgroundImage: 'url(' + waitImg + ')'
    }
    return (
      <div >
        {this.state.challengeCanceled && <Redirect to="/"/>}
        <h1 className="waitingMsg"> We are waiting for <span className="userWating">{this.props.name}</span> to accept your challenge! </h1>
        <img src={waitImg} alt="Waiting" className="waitingImg"/>
        <BottomBar>
        <div className="row">
            <div className="col-6">
              <button className="btn btn-secondary button-secondary" onClick={this.cancelChallenge.bind(this)}>
                Cancel Challenge
              </button>
            </div>
          </div>
        </BottomBar>
      </div>
    );
  }
  
  cancelChallenge(){
    api.cancelChallenge().then((res)=>{
      this.setState({challengeCanceled: true})
    })
  }
}

export default WaitScreen;
