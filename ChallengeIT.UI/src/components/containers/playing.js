import React, { Component } from 'react';
import * as api from '../../apiCaller';
import ChallengeUserPanel from '../challengeUserPanel';
import BottomBar from '../bottomBar';
import { Redirect, Link } from 'react-router-dom';
import playImg from '../../assets/img/playing.gif';
import winImg from '../../assets/img/winner.gif';
import looserImg from '../../assets/img/looser.gif';
import { connect } from "react-redux";
import * as challengeActions from "../../actions/challengeActionCreator";

class PlayingScreen extends Component {
  constructor(props){
    super(props);
    this.state = {challengeCanceled: false};
  }
  render() {
    let styles = {
      backgroundImage: 'url(' + playImg + ')'
    }
    return (
      <div >
        {this.state.challengeCanceled && <Redirect to="/"/>}
        {this.state.changeFinished && <Redirect to="/"/>}
        {this.state.finishChallenge && this.showConfirmation()}
        {this.state.userWon && this.showFinalMsg(true)}
        {this.state.userLost && this.showFinalMsg()}
        {this.state.finishChallenge && this.showConfirmation()}
        {!this.state.finishChallenge && this.renderPlayingDialog()}
        
      </div>
    );
  }

  markChallengeWin(){
    this.setState({userWon:true});
  }

  markChallengeLost(){
    this.setState({userLost:true});
  }

  showFinalMsg(won){
    if(won)
    return <React.Fragment>
      <h1 className="waitingMsg"> Congratulations! </h1>
          <img src={winImg} alt="Waiting" className="waitingImg"/>
          <BottomBar>
          <div className="row">
            <div className="col-6">
              <Link to="/categories">
                <button className="btn btn-secondary button-secondary" onClick={this.finishChallenge.bind(this)}>
                  Play Again
                </button>
              </Link>
            </div>
            </div>
          </BottomBar>
    </React.Fragment>

    return <React.Fragment>
    <h1 className="waitingMsg"> We wish you best luck next time! </h1>
        <img src={looserImg} alt="Waiting" className="waitingImg"/>
        <BottomBar>
        <div className="row">
          <div className="col-6">
            <Link to="/categories">
              <button className="btn btn-secondary button-secondary" onClick={this.finishChallenge.bind(this)}>
                Play Again
              </button>
            </Link>
          </div>
          </div>
        </BottomBar>
    </React.Fragment>

  }

  showConfirmation(){
    return <React.Fragment>
    <h1 className="waitingMsg"> We hope you enjoyed your challenge!</h1>
    <h1 className="waitingMsg"> How did it go?</h1>
        <img src={playImg} alt="Waiting" className="waitingImg"/>
        <BottomBar>
        <div className="row">
          <div className="col-6">
            <button className="btn btn-secondary button-secondary" onClick={this.markChallengeWin.bind(this)}>
              I won! =)
            </button>
          </div>
            <div className="col-6">
              <button className="btn btn-secondary button-secondary" onClick={this.markChallengeLost.bind(this)}>
                I lost =(
              </button>
            </div>
          </div>
        </BottomBar>
  </React.Fragment>
}
  

  renderPlayingDialog(){
    return <React.Fragment>
      <h1 className="waitingMsg"> Play your challenge!</h1>
          <img src={playImg} alt="Waiting" className="waitingImg"/>
          <BottomBar>
          <div className="row">
            <div className="col-6">
              <button className="btn btn-secondary button-secondary" onClick={this.finishChallenge.bind(this)}>
                Finish Challenge
              </button>
            </div>
              <div className="col-6">
                <button className="btn btn-secondary button-secondary" onClick={this.cancelChallenge.bind(this)}>
                  Cancel Challenge
                </button>
              </div>
            </div>
          </BottomBar>
    </React.Fragment>
  }

  finishChallenge(){
    this.setState({finishChallenge: true});
  }
  
  cancelChallenge(){
    api.cancelChallenge().then((res)=>{
      this.setState({challengeCanceled: true})
    })
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


export default connect(mapStateToProps, mapDispatchToProps)(PlayingScreen);
