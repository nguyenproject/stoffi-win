# Change Log
All notable changes to [stoffi-player-win](https://github.com/simplare/stoffi-player-win) will be documented in this file.
From version 1.50.0 and onward, this project adheres to [Semantic Versioning](http://semver.org/).
This change log is based on [Keep a CHANGELOG](http://keepachangelog.com/).

## Unreleased (han)
### Added
- Stream from [Jamendo](http://jamendo.com).
- New views: icon grid, content, icon list.
- Album art downloader from [Last.fm](http://last.fm).
- Ability to stop playback after a song ends.
- A huge number of preloaded radio stations has been added.
- YouTube can now be played in fullscreen.
- YouTube playlists can now be imported by URL.
- Special playlists based on a search filter. Whenever new songs are detected, matching the search, they are automatically added to the playlist.

### Changed
- The Core is now a separate project: [stoffi-player-core](https://github.com/simplare/stoffi-player-core).
- The Plugin API is now a separate project: [stoffi-player-plugin](https://github.com/simplare/stoffi-player-plugin).

## 1.39.930.9944 - 2014-05-06 (qin)
### Added
- Stream from [SoundCloud](http://soundcloud.com).
- Listen to Internet radio.
- Associate file formats with Stoffi.
- Plugins can now specify settings.
- Synchronize playlists between devices.
- New type of plugin: filter (can change volume for example).
- A bunch of equalizer profiles shipped by default.
- A dialog on first startup asking to associate filetypes.

### Removed
- Dialog showing that settings are being saved when closing app.

### Fixed
- Playlist file imports now works properly.
- No more computer from sleeping while playing music.
- Cloud API can now handle UTF8 encoding.
- Pressing `-` in numpad now works while renaming playlist.
- Empty meta data (*Artist* and *Title*) is now auto filled with a guess based on filename.
- Folders can now be dropped onto a playlist, adding any songs in it.
- Timestamps are now displayed according to regional settings.

## 1.34.169.8631 - 2012-06-27 (zhou)
### Added
- Connect to a Stoffi account.
- Share songs with friends on Facebook and Twitter.
- Generate playlists with the new playlist generator.
- A new plugin system for visualizers.
- An indicator that a search filter is active.
- Copy and move files from within Stoffi.
- German translation.
- Songs can now be copied and moved using context menu.

### Fixed
- No more rare crash when a song ends.
- Songs added in batch to queue are added in the order they were selected.
- Fixed some bugs regarding playlists with numbers in their name.
- Cursor will now change when hovering an item in the navigation pane.
- Bugs in the property window have been fixed.
- Bugs with the `F2` button have been fixed.
- No more crash when renaming files being observed.
- Scroll position is now preserved between app restarts.
- Bugs with context menus have been fixed.

## 1.32.223.2654 - 2011-11-03 (shang hotfix 1)
### Fixed
- No more crash when playing YouTube track without Flash installed.

## 1.31.981.5721 - 2011-10-30 (shang)
### Added
- [YouTube](http://youtube.com) streaming.
- Swedish and Chinese translations.
- Tooltip when changing volume.
- Automatic compression of layout when window size decreases.
- *Restart* button in upgrade notification.
- Warning when closing the app while an upgrade is in progress.
- Taskbar progressbar while upgrade is in progress.
- Meta data can now be edited inside the details pane.

### Changed
- Redesign property window for track meta data
- Scanner has been rewritten from scratch
- List view has been rewritten from scratch
- Stoffi now installs into `AppData` instead of `C:\Program Files`, removing the need for requiring admin permissions when upgrading.
- Errors and warnings regarding the upgrader are now displayed next to the upgrade settings, instead of in a popup dialog.

### Removed
- Highly unstable Milkdrop visualizer

### Fixed
- Playing a song from the context menu is now working.
- No more crash when reordering columns in lists.
- Polished all icons.
- Bug with renaming of folders not being detected have been fixed.
- There is now a tooltip at the volume slider.

## 1.30.393.1053 - 2011-05-05 (xia)
The first stable release of Stoffi Music Player. (This is what we would call version 1.0 in [Semantic Versioning](http://semver.org/).)

### Changed
- Renamed installer from `Install Stoffi.exe` to `InstallStoffi.exe`.
- Equalizer is now fixed size.

### Removed
- Shortcut to show visualizer has been removed.

### Fixed
- No more crash when doing a search after renaming a playlist.
- Changing sorting in a list will now keep selection in view.
- Pressing `Esc` will now close window for renaming keyboard shortcut profile.
- Dropping a song on *Create new* will now create a new playlist.

## 1.30.325.1235 - 2011-04-20 (xia beta 11)
### Changed
- Setting for enabling Milkdrop visualizers has been moved from inside the app to the file `user.config`.
- Changing search policy will now reset active searches.
- Equalizer no longer always on top.
- Shortcut to restore app has been changed from `Ctrl`+`R` to `Ctrl`+`Shift`+`R`.

### Removed
- Removed confirmation dialog when closing the app.

### Fixed
- Bug with the highlight of the current song disappearing has been fixed.
- Various bugs with *Open with Stoffi* has been fixed.
- Bug with songs disappearing from *History* and *Queue* has been fixed.
- Bug causing newly added song to not show up has been fixed.
- Bugs and crashes when deleting an observed folder has been fixed.
- Equalizer bands have been put in the correct order.
- Deleting multiple songs using a shortcut now works properly.
- Bugs causing keyboard shortcuts to not work has been fixed.
- No more crash when placing bookmarks very close to each other.
- No more playlists with the same name.
- Bugs regarding the tray has been fixed.

## 1.30.002.6716 - 2011-03-15 (xia beta 10)
### Added
- Indicator to show status for the automatic scanner

### Fixed 
- Sorting in *History* now works properly if two songs are played the same second.
- The look of the equalizer has been polished.
- Text in *About* now wraps properly.
- Pressing `Ctrl`+`A` will select all songs, even when current selection is empty.
- Playlists now appear in the *Add to playlist* context menu as they should.
- Removing multiple songs is now possible.

## 1.29.915.8968 - 2011-03-03 (xia beta 9)
### Added
- The installer now unpacks itself, no manual unpacking needed.

### Changed
- Shortcut for playing selected song changed to `Enter`.
- Shortcut for removing playlist changed to `Delete`.
- Moved from GPLv2 to GPLv3.

### Fixed
- Selection is no longer clear when performing a search.
- Various bugs regarding focus have been fixed.
- Size and position of equalizer is perserved between app restarts.
- Labels in equalizer have been polished.
- Correct indicator (copy/move) is now shown when tracks are dragged.
- Minor adjustment of spacing in playback pane.
- Equalizer now stretches properly during resize.
- Various bugs with `Delete` not working.
- Prevent adding of sources that are already observed.
- Fix *Play* button in start menu.
- Pressing on a bookmark now casues playback to jump to that position.
- Pressing *Next* while *Repeat one* is active will now jump to the next song.
- Songs inside *Recycle Bin* are no longer displayed.
- No more crash when pressing *Next* while being at the end of the list.
- *Shuffle* now honor any active search filter.
- No more 1-second-freeze when changing settings.
- No more crashes when scanning files with Chinese filenames.
- No more duplicates inside playlists.
- No more crash when opening an unobserved file with Stoffi.

## 1.29.753.3559 - 2011-02-12 (xia beta 8)
### Changed
- Shortcut for *About* page is changed from `Ctrl`+`A` to `Alt`+`A`.
- The new, experimental Milkdrop visualizer is now hidden behind a setting.

### Fixed
- Highlight of current song is no longer lost when pressing *Next* rapidly.
- Reordering queue will now affect the order that the queue is played.
- *Length* column is now right aligned.
- Prevent multiple equalizer windows.
- Active navigation is perserved between app restarts.
- No more crash when opening a file with Stoffi.
- Position numbers in the queue are now in correct order.
- A few spelling mistakes.
- No more error on startup unless connected to the Internet.

## 1.29.639.4244 - 2011-01-30 (xia beta 7)
### Added
- Keyboard shortcuts for jumping between bookmarks.

## 1.29.586.5771 - 2011-01-26 (xia beta 6)
### Added
- Sorted column is now emphasised in bold.
- Place bookmarks in tracks.
- A new, very unstable, MilkDrop visualizer.
- Ability to save and load playlists.
- You can now repeat just a single song. (Why would anyone do that?)
- Keyboard shortcut to jump to current song.
- Edit meta data of multiple songs at the same time.
- Currently playing song is now highlighted in green.
- Tune the sound using a new equalizer

### Changed
- Renamed link in start menu from Stoffi to Stoffi Music Player.
- Searches will now by default only apply to the current list. This can be changed in a setting.
- Properties of lists (sorting, column order, etc.) are no longer shared between lists.

### Removed
- Unnecessary folder in start menu.

### Fixed
- Buttons no longer disappears from thumbnail in taskbar.
- `F2` will now trigger a playlist rename.
- Playlist rename is saved when losing focus.
- The interface can now be tabbed through.
- Songs the queue can now be reordered.
- Repeat now works when shuffle is enabled.
- Pressing `Esc` while renaming playlist will now cancel the edit.
- Media buttons now only registers once when app is in focus.
- No more crash when removing the currently playing song.
- Ordering on dates now works with AM/PM formats.
- Previous button now works as expected.
- No more crash when opening and clicking in context menus without an active selection.
- No more rare crashes when pressing *Next* and *Previous* repeatedly.
- No more crash when scanning folders without read permission.
- Ordering on song length now works as expected.

## 1.28.856.3135 - 2010-11-01 (xia beta 5)
### Added
- Use (almost) the same keyboard shortcuts as in your previous player.
- An *Add* button in the toolbar allows you to... add stuff!

### Changed
- Rephrased the text on the *About* page in *Preferences*.
- Polished the sort indicator in column header of lists.
- *Play count* is incremented when song ends instead of when it starts.
- Search will now match against filename in addition to meta data.

### Fixed
- Unsupported files (mp4, mov) will not appear.
- Aero Snap works on screens as small as 1024 pixels wide.
- Deleting a selected playlist will jump to the last selected view.
- Songs newly discovered will appear when a search is active.
- Double-clicks on songs are now registered if the mouse is on the *Artist* field.
- *Play count* is now consistent between lists.
- No more crash when a non-existent path is added to an observed *Library*.
- Pressing ↑ or ↓ when song is selected now works as expected.
- Scrolling horizontally will no longer cause first track to be selected.
- Holding shift while selecting now works as expected.

## 1.28.464.5931 - 2010-09-20 (xia beta 4)
### Added
- Support for over 20 more file formats, in addition to mp3 and wma.
- A new, cool MSI installer.

### Changed
- Increased visibility of the buttons *Shuffle* and *Repeat*.
- Classic theme for when the user changes Windows' theme to *Classic*.
- Playback is now handled by BASS instead of `MediaElement`.

### Removed
- The old, cranky ClickOnce installer.

### Fixed
- No more duplicates in *Sources*.
- List meta data (eg *Total playing time*) now works on all lists.
- No more crash when adding a file source.
- *Next* will now work when paused.
- Buttons in the menu bar now work.
- Drag-n-drop now works when multiple songs are selected.
- Sorting in lists is now perserved between app restarts.
- No more crash when double-clicking the handle inside column headers of lists.

## 1.28.381.3488 - 2010-09-06 (xia beta 3)
### Changed
- Rephrased the text on the *About* page in *Preferences*.

## 1.28.334.7876 - 2010-09-01 (xia beta 2)
### Added
- View and edit meta data of tracks.

### Removed
- Removed *Queue song* from the context menus in *History* and *Queue*.

### Fixed
- The fields in *Last played* and *Play count* now updates properly.
- Fixed the text *Remove from ...* in the context menus in *History* and *Queue*.
- Volume level is perserved between app restarts.
- No more crash when selecting track in *Queue* or *History*.

## 1.28.239.2727 - 2010-04-30 (xia beta 1)
### Added
- Settings!
- Automatic upgrader!
- Tray icon!
- Notifications!
- Jumplists!

### Changed
- Rename from *Yet Another Music Application* to *Stoffi*.

## 0.1 - 2010-04-24 (xia alpha)
### Added
- Use playlists to organise your tracks.
- An automatic scanner automatically finds your tracks.
- A distinct Aero look, melting into Windows 7.