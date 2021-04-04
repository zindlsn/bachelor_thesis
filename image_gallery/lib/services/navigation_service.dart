import 'package:flutter/material.dart';

//https://medium.com/flutter-community/clean-navigation-in-flutter-using-generated-routes-891bd6e000df
class NavigationService {
  final GlobalKey<NavigatorState> navigatorKey =
      new GlobalKey<NavigatorState>();
  GlobalKey<ScaffoldState> scaffoldKey = new GlobalKey<ScaffoldState>();

  Future<dynamic> navigateTo(String routeName, {dynamic arguments}) {
    return navigatorKey.currentState!
        .pushNamed(routeName, arguments: arguments);
  }

  void goBack() {
    navigatorKey.currentState!.pop();
  }
}
