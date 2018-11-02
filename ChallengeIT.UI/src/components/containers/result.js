import React, { Component } from 'react';
import * as api from '../../apiCaller';
import ChallengeUserPanel from '../challengeUserPanel';
import BottomBar from '../bottomBar';
import { Redirect } from 'react-router-dom';
import playImg from '../../assets/img/playing.gif';
import { connect } from "react-redux";
import * as challengeActions from "../../actions/challengeActionCreator";

class ResultScreen extends Component {
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
        {!this.state.finishChallenge && this.renderPlayingDialog()}
        
      </div>
    );
  }

  showConfirmation(){
    return <React.Fragment>
    <h1 className="waitingMsg"> Well done! Now please tell us, who won?</h1>
        <img src={playImg} alt="Waiting" className="waitingImg"/>
        <ul className="coolList">
          {this.state.filteredUsers.map(user => (
            <li key={user.id} onClick={this.selectUser.bind(this, user.id)}>
              {user.name}
            </li>
          ))}
          {this.state.filteredUsers.length === 0 && <h2>No users found :-(</h2>}
        </ul>
  </React.Fragment>
  }

  renderPlayingDialog(){
    return <React.Fragment>
      <h1 className="waitingMsg"> We hope you enjoyed your challenge!</h1>
      <h1 className="waitingMsg"> How did it go?</h1>
          <img src={playImg} alt="Waiting" className="waitingImg"/>
          <BottomBar>
          <div className="row">
            <div className="col-6">
              <button className="btn btn-secondary button-secondary" onClick={this.finishChallenge.bind(this)}>
                I won! =)
              </button>
            </div>
              <div className="col-6">
                <button className="btn btn-secondary button-secondary" onClick={this.cancelChallenge.bind(this)}>
                  I lost =(
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


export default connect(mapStateToProps, mapDispatchToProps)(ResultScreen);
