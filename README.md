Welcome to Stoffi
=================

![Screenshot](https://www.stoffiplayer.com/assets/us/start.png)

Welcome to the world's next music player.

This project should not be taken very seriously. It is mostly a playground for me, allowing me to experiment with different technologies in something that resembles a real world project. However, over the last couple of years Stoffi has grown into something that's no longer very tiny or limited in scope. I've actually managed to create quite a few features.

Go to [stoffiplayer.com](http://stoffiplayer.com) for more information and to download the player.

## Features

* Streaming from YouTube, SoundCloud, Internet radio
* Sharing on Facebook, Twitter and Last.fm
* Uploading listens to Facebook and Last.fm
* Cloud synchronization
* Playlist subscriptions
* Dynamic playlists
* Plugins (visualizers and filters)
* Random playlist generator
* Silent upgrades (no interaction needed)
* Bookmarks
* Remote control

## Compile from source
Clone the repository:

    git clone https://github.com/simplare/stoffi-player-win.git
    
The initialize the [Stoffi Core](https://github.com/simplare/stoffi-player-core) submodule:

    cd Core
    git submodule init
    git submodule update
    
Copy the file `Core/Services/Keys.tmpl.cs` to `Core/Services/Keys.cs` and edit it, adding the API keys and secrets Stoffi needs. You can get the keys here:

 * [stoffiplayer.com](https://www.stoffiplayer.com/apps/new)
 * [Jamendo](https://devportal.jamendo.com/admin/applications/new)
 * [Last.fm](http://www.last.fm/api/account/create)
 * [Bass.Net](http://www.bass.radio42.com/bass_register.html)
 * [SoundCloud](https://soundcloud.com/you/apps)
 * [YouTube](https://cloud.google.com/console)

For getting access to YouTube you need to go to the [Google Developer Console](https://cloud.google.com/console) and register a new project. Under this new project you then need to go to *APIs & auth* > *Credentials* and create a new browser key for Public Key Access.
