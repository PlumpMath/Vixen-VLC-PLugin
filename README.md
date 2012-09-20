Vixen-VLC-PLugin
================

Plugin for Vixen to send commands to vlc

This plugin allows you to send start and stop http commands to a VLC host, based on intensity levels of a channel.

The playlist is really limited to 49 items, because you need a start and stop intensity from 1-100

If you do not set a stop intensity then the playlist will continue when the clip that was started ends.

On systems I tested, the playlist on the xml host started with ID 5 so the black.wmv clip is assumed to be 5
To see what your xml playlist looks like, go to http://<host ip>:<host port>/requests/playlist.xml
