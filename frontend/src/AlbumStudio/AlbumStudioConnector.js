import PropTypes from 'prop-types';
import React, { Component } from 'react';
import { createSelector } from 'reselect';
import connectSection from 'Store/connectSection';
import createClientSideCollectionSelector from 'Store/Selectors/createClientSideCollectionSelector';
import { setAlbumStudioSort, setAlbumStudioFilter, saveAlbumStudio } from 'Store/Actions/albumStudioActions';
import { fetchAlbums, clearAlbums } from 'Store/Actions/albumActions';
import AlbumStudio from './AlbumStudio';

function createMapStateToProps() {
  return createSelector(
    createClientSideCollectionSelector(),
    (artist) => {
      return {
        ...artist
      };
    }
  );
}

const mapDispatchToProps = {
  fetchAlbums,
  clearAlbums,
  setAlbumStudioSort,
  setAlbumStudioFilter,
  saveAlbumStudio
};

class AlbumStudioConnector extends Component {

  //
  // Lifecycle

  componentDidMount() {
    this.populate();
  }

  componentWillUnmount() {
    this.unpopulate();
  }

  //
  // Control

  populate = () => {
    this.props.fetchAlbums();
  }

  unpopulate = () => {
    this.props.clearAlbums();
  }

  //
  // Listeners

  onSortPress = (sortKey) => {
    this.props.setAlbumStudioSort({ sortKey });
  }

  onFilterSelect = (filterKey, filterValue, filterType) => {
    this.props.setAlbumStudioFilter({ filterKey, filterValue, filterType });
  }

  onUpdateSelectedPress = (payload) => {
    this.props.saveAlbumStudio(payload);
  }

  //
  // Render

  render() {
    return (
      <AlbumStudio
        {...this.props}
        onSortPress={this.onSortPress}
        onFilterSelect={this.onFilterSelect}
        onUpdateSelectedPress={this.onUpdateSelectedPress}
      />
    );
  }
}

AlbumStudioConnector.propTypes = {
  setAlbumStudioSort: PropTypes.func.isRequired,
  setAlbumStudioFilter: PropTypes.func.isRequired,
  fetchAlbums: PropTypes.func.isRequired,
  clearAlbums: PropTypes.func.isRequired,
  saveAlbumStudio: PropTypes.func.isRequired
};

export default connectSection(
  createMapStateToProps,
  mapDispatchToProps,
  undefined,
  undefined,
  { section: 'artist', uiSection: 'albumStudio' }
)(AlbumStudioConnector);
