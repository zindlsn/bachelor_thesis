import 'dart:async';

import 'package:shared_preferences/shared_preferences.dart';

class UserPreferenceService {
  static const kThemestatus = "lighttheme";

  StreamController<bool> isLightThemeChosen =
      StreamController.broadcast(sync: false);

  Future<void> setLightThemeAsync(bool value) async {
    SharedPreferences prefs = await SharedPreferences.getInstance();
    prefs.setBool(kThemestatus, value);
    isLightThemeChosen.add(value);
  }

  Future<bool> isLightThemeAsync() async {
    SharedPreferences prefs = await SharedPreferences.getInstance();
    return prefs.getBool(kThemestatus) ?? false;
  }

  Future<void> loadThemePreferenceAsync() async {
    isLightThemeChosen.add(await isLightThemeAsync());
  }
}
