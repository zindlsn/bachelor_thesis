import 'dart:core';
import 'dart:io';

import 'package:image_gallery/main.dart';
import 'package:image_gallery/models/gallery_image.dart';
import 'package:image_gallery/mvvm/base_model.dart';
import 'package:image_gallery/services/file_selector_service.dart';
import 'package:image_gallery/services/user_preference_service.dart';

class ImageGalleryPageViewModel extends BaseModel {
  var fileSelectorService = locator<FileSelectorService>();

  List<GalleryImage> images = [];

  /*Future<void> loadImages() async {
    setState(ViewState.Busy);
    final file = OpenFilePicker()
      ..filterSpecification = {
        'Word Document (*.doc)': '*.doc',
        'Web Page (*.htm; *.html)': '*.htm;*.html',
        'Text Document (*.txt)': '*.txt',
        'All Files': '*.*'
      }
      ..defaultFilterIndex = 0
      ..defaultExtension = 'doc'
      ..title = 'Select a document';

    final result = file.getFile();
    if (result != null) {
      GalleryImage image = GalleryImage()
        ..path = result.path;
      images.add(image);
    }
    setState(ViewState.Idle);
  } */

  Future<void> loadImagesAsync() async {
    setState(ViewState.Busy);
    try {
      final files = await fileSelectorService.openFileSelectorAsync();
      for (var file in files) {
        GalleryImage image = GalleryImage()
          ..path = file.path
          ..title = file.name;
        images.add(image);
      }
    } catch (e) {
      String errorMessage = 'Files could not be loaded';
      this.setErrorMessage(errorMessage);
      throw new FileSystemException(errorMessage);
    }
    setState(ViewState.Idle);
  }

  UserPreferenceService darkThemePreference = UserPreferenceService();
  bool _lightTheme = false;

  bool get lightTheme => _lightTheme;

  set lightTheme(bool lightTheme) {
    _lightTheme = lightTheme;
    notifyListeners();
  }

  Future<void> changeThemeAsync() async {
    lightTheme = !lightTheme;
    await darkThemePreference.setLightThemeAsync(lightTheme);
  }
}
