import { app, BrowserWindow, Menu, Tray, ipcMain } from 'electron'

/**
 * Set `__static` path to static files in production
 * https://simulatedgreg.gitbooks.io/electron-vue/content/en/using-static-assets.html
 */
if (process.env.NODE_ENV !== 'development') {
  global.__static = require('path').join(__dirname, '/static').replace(/\\/g, '\\\\')
}

let mainWindow
const winURL = process.env.NODE_ENV === 'development'
  ? `http://localhost:9080`
  : `file://${__dirname}/index.html`

function createWindow () {
  /**
   * Initial window options
   */
  mainWindow = new BrowserWindow({
    height: 563,
    useContentSize: true,
    width: 1000
  })

  mainWindow.loadURL(winURL)

  mainWindow.on('closed', () => {
    mainWindow = null
  })
}

app.on('ready', () => {
  createWindow()

  //タスクトレイに格納
  var appIcon = new Tray(__static + '/image/icon.png')
  const contextMenu = Menu.buildFromTemplate([
      {label: 'Close(Q)', accelerator: 'Command+Q', click: () => app.quit()}
  ])
  appIcon.on('click', () => {
    if (mainWindow) {
      if (mainWindow.isMinimized()){
        mainWindow.focus()
      } else if (mainWindow.isVisible()) {
        mainWindow.show()
      }
    } else {
      createWindow()
    }
  })
  appIcon.setToolTip('SekiPa : 座席管理システム')
  appIcon.setContextMenu(contextMenu)
})

app.on('window-all-closed', () => {})

app.on('activate', () => {
  if (mainWindow === null) {
    createWindow()
  }
})

/**
 * Auto Updater
 *
 * Uncomment the following code below and install `electron-updater` to
 * support auto updating. Code Signing with a valid certificate is required.
 * https://simulatedgreg.gitbooks.io/electron-vue/content/en/using-electron-builder.html#auto-updating
 */

const {autoUpdater} = require("electron-updater")

autoUpdater.on('update-downloaded', () => {
  autoUpdater.quitAndInstall()
})

app.on('ready', () => {
  if (process.env.NODE_ENV === 'production') autoUpdater.checkForUpdates()
})
