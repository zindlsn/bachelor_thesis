import 'dart:async';

import 'package:flutter/material.dart';
import 'package:get_it/get_it.dart';
import 'package:image_gallery/globals.dart';
import 'package:image_gallery/pages/image_detail_page/image_detail_page_view_model.dart';
import 'package:image_gallery/pages/image_gallery_page/image_gallery_page.dart';
import 'package:image_gallery/pages/image_gallery_page/image_gallery_page_view_model.dart';
import 'package:image_gallery/pages/image_gallery_page/image_view_model.dart';
import 'package:image_gallery/router.dart';
import 'package:image_gallery/services/file_selector_service.dart';
import 'package:image_gallery/services/user_preference_service.dart';
import 'package:image_gallery/themes.dart';

import 'file:///D:/repos/Bachelor_Arbeit/Code/code/image_gallery/lib/services/navigation_service.dart';

GetIt locator = GetIt.instance;

ThemeMode currentThemeMode = ThemeMode.light;

Future<void> main() async {
  WidgetsFlutterBinding.ensureInitialized();

  locator.registerFactory<ImageGalleryPageViewModel>(
      () => ImageGalleryPageViewModel());
  locator.registerFactory<ImageViewModel>(() => ImageViewModel());
  locator.registerFactory<ImageDetailPageViewModel>(
      () => ImageDetailPageViewModel());

  locator.registerLazySingleton(() => NavigationService());
  locator.registerLazySingleton(() => UserPreferenceService());
  locator.registerLazySingleton(() => FileSelectorService());
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
        title: 'Flutter Demo',
        debugShowCheckedModeBanner: false,
        navigatorKey: locator<NavigationService>().navigatorKey,
        initialRoute: kImageGalleryPage,
        onGenerateRoute: RouteGenerator.generateRoute,
        darkTheme: Styles.theme(true, context),
        theme: Styles.theme(false, context),
        themeMode: ThemeMode.light,
        home: ImageGalleryPage());
  }
}
