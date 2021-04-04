import 'package:flutter/material.dart';

/// https://github.com/FilledStacks/flutter-tutorials/blob/master/025-navigation-service/02-final/lib/viewmodels/basemodel.dart
/// Represents the state of the viewmodel
enum ViewState { Idle, Busy }

///
/// Base model for all view models.
///
class BaseModel extends ChangeNotifier {
  ViewState _state = ViewState.Idle;

  ViewState get state => _state;

  late String _errorMessage;
  String get errorMessage => _errorMessage;
  bool get hasErrorMessage => _errorMessage != null && _errorMessage.isNotEmpty;

  void setErrorMessage(String message) {
    _errorMessage = message;
    notifyListeners();
  }

  ///
  /// Sets the state of the view model
  void setState(ViewState viewState) {
    _state = viewState;
    notifyListeners();
  }
}
