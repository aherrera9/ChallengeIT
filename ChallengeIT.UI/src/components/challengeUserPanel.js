import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import * as api from '../apiCaller';
import BottomBar from './bottomBar';

class ChallengeUserPanel extends Component {
  render() { 
    return (
      <div className="col-12">
        <h2>You are about to challenge: </h2>
        <h1 className="challengeUserName">{this.props.name}</h1>
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

  challengePlayer() {}
}

export default ChallengeUserPanel;
