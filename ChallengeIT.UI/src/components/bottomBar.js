import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import * as api from '../apiCaller';

class BottomBar extends Component {
  render() {
    return (
      <div className="bottomBar">
        {this.props.children}
      </div>
    );
  }

  challengePlayer() {}
}

export default BottomBar;
